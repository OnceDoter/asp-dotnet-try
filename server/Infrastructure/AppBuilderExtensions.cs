using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebApi.Infrastructure
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                    .UseSwaggerUI(x =>
                    {
                        x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        x.RoutePrefix = string.Empty;
                    });
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            /*using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<WebApiDbContext>();
            dbContext.Database.Migrate();*/
        }
        public static void Then(this Task obj, Action action)
            => action();
    }
}
