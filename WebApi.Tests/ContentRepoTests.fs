module WebApi.Tests

open Microsoft.AspNetCore.Mvc
open NUnit.Framework
open System.Threading.Tasks
open WebApi.Controllers.Pictures
open WebApi.Data
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open WebApi.Data.Models

let threadsCount = 10
let testEntitiesCount = 50

let contexts = [
    for c in 0..threadsCount -> new WebApiDbContext(
                                    let builder = new DbContextOptionsBuilder<WebApiDbContext>()
                                    builder.UseSqlServer(
                                        let cfg = new ConfigurationBuilder()
                                        cfg
                                            .AddJsonFile("appsettings.json")
                                                .Build()
                                            .GetSection("ConnectionStrings")
                                            .GetSection("TestConnection").Value).Options)
]

[<SetUp>]
let Setup () = ()

[<Test>]
let PictureService_change_entities_in_10_threads_return_no_DbUpdateConcurrencyException () =
    let expected = true
    //init concurrent services
    //create test entities
    let services =  [for i in 0..threadsCount-1 -> new PictureService (contexts.[i])]
    
    services.Head.Create(
                            [|for i in 0..testEntitiesCount-1 do new Image("test descr #" + i.ToString())|]
                        ) |> ignore
    let images = services.[1].GetImages()
    let enum = images.GetEnumerator()
    let tasks = Array.zeroCreate threadsCount
    //methods need to check result
    let check (result : ActionResult) : bool =
        match result with
        | ok when ok = (upcast new OkResult() : ActionResult) -> true
        | _ -> false
    let mutable list = [true]
    let add (result : bool) : unit =
        list <- result :: list
    //simulate concurrent access
    try
    let act (service : PictureService) = 
        async{
            for i in 0..testEntitiesCount-1 do service.Update(enum.Current)
                                               |> check
                                               |> add
        } |> ignore
    for i in 0..threadsCount-1 do
            tasks.[i] =
                Task.Factory.StartNew(
                                         fun () -> act <| services.[i]
                                     ) |> ignore
    finally
    Task.WaitAll()
    //lets check
    let mutable actual = true
    for item in list do
            if (not item) then actual <- false    
            
    Assert.AreEqual(expected, actual)