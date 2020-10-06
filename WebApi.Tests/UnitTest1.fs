module WebApi.Tests

open NUnit.Framework
open WebApi.Data
open AngularWebApi.Data
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open WebApi.Data.Models
open AngularWebApi.Data.Models


let context = new WebApiDbContext(
                let builder = new DbContextOptionsBuilder<WebApiDbContext>()
                builder.UseSqlServer(
                    let cfg = new ConfigurationBuilder()
                    cfg
                        .AddJsonFile("appsettings.json")
                            .Build()
                        .GetSection("ConnectionStrings")
                        .GetSection("TestConnection").Value).Options)

type Repositories = {
    Image : ContentRepository<Image>
    Audio : ContentRepository<Audio>
    Video : ContentRepository<Video>
} 


[<SetUp>]
let Setup () = ()
   


[<Test>]
let Test1 () =
    Assert.Pass()