namespace WebApplication1
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using WebApplication1.Infrastructure;

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationSection = Configuration.GetSection("AppSettings");
            Settings = ConfigurationSection.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }
        public IConfigurationSection ConfigurationSection { get; }
        public AppSettings Settings { get; }


        public void ConfigureServices(IServiceCollection services)
            => services
                .AddCors()
                .Configure<AppSettings>(ConfigurationSection)
                .AddDatabase(Configuration)
                .AddIdentity()
                .AddJwtBearerAuth(Settings)
                .AddApplicationServices()
                .AddSwagger()
                .AddControllers();
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(x =>
                {
                    x.MapControllers();
                })
                .ApplyMigrations();
        }
    }
}
