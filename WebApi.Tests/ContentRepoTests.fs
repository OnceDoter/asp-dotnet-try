module WebApi.Tests

open NUnit.Framework
open System.Threading.Tasks
open WebApi.Controllers.Pictures
open WebApi.Data
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open WebApi.Data.Models
open System.Collections

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

let isEmpty (x:obj) =
    match x with
    | null -> true
    | :? System.Collections.IEnumerable as xs -> xs |> Seq.cast |> Seq.isEmpty
    | _ -> invalidOp <| "unsupported type " + x.GetType().FullName

[<Test>]
let PictureService_change_entities_in_10_threads_return_no_DbUpdateConcurrencyException () =
    let expected = ()
    //use best practics
    let fail (methName : string) = Assert.Fail <| "<"+methName+">" + "return null"
    //init concurrent servises
    //create test entities
    let iservices =  [for i in 0..threadsCount -> new PictureService (contexts.[0])]
    iservices.Head.Create([|for i in 0..testEntitiesCount do new Image("test descr #" + i.ToString())|]) |> ignore
    let imgs = iservices.[0].GetImages() |> Seq.cast<Image>
    if isEmpty imgs then fail "GetImages()"
    //simulate concurrent access
    let act (service : PictureService) = 
        for i in 0..testEntitiesCount do 
            ()
    let actual = for service in iservices do Task.Run(act(service))
                    


    let ares = Array.zeroCreate testEntitiesCount
    let vres = Array.zeroCreate testEntitiesCount
    (*let actual = async {
        let imgs = repos.Images.GetImages() |> Seq.cast<Image>
        imgs.[1]
        for e in 0 .. testEntitiesCount do
            Task.Factory.StartNew(
                fun() -> for img in imgs do
                    
            )
        
    }*)
    let actual = ()
    Assert.AreEqual(expected, actual)