module WebApi.Tests

open NUnit.Framework
open WebApi.Data
open AngularWebApi.Data
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open System


let context = new WebApiDbContext(
                let builder = new DbContextOptionsBuilder<WebApiDbContext>()
                builder.UseSqlServer(
                    let cfg = new ConfigurationBuilder()
                    cfg
                        .AddJsonFile("appsettings.json")
                            .Build()
                        .GetSection("ConnectionStrings")
                        .GetSection("TestConnection").Value).Options)
let repos () =
    [|
        new ContentRepository<'Image>(context)
        new ContentRepository<'Audio>(context)
        new ContentRepository<'Video>(context)
    |]


[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    Assert.Pass()
