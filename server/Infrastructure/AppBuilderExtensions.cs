using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;

namespace WebApplication1.Infrastructure
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
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<VideoContext>();
            dbContext.Database.Migrate();
        }
    }
}
