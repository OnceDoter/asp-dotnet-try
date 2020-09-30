using AngularWebApi.Data;
using AngularWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections;
using WebApi.Data;
using WebApi.Data.Models;

namespace WebApiUnitTesting
{
    public class Tests
    {
        private ArrayList repos;
        private WebApiDbContext context;

        [SetUp]
        public void Setup()
        {
            context = new WebApiDbContext(new DbContextOptionsBuilder<WebApiDbContext>()
                .UseSqlServer(
                    new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                        .Build()
                        .GetSection("ConnectionStrings")
                        .GetSection("TestConnection")
                        .Value)
                    .Options);
            repos = new ArrayList()
            {
                new ContentRepository<Image>(context),
                new ContentRepository<Audio>(context),
                new ContentRepository<Video>(context)
            };
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}