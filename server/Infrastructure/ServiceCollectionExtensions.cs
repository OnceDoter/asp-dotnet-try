using System.Text;
using AngularWebApi.Controllers.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApi.Controllers.Identity;
using WebApi.Controllers.Music;
using WebApi.Controllers.Pictures;
using WebApi.Controllers.Users;
using WebApi.Controllers.Videos;
using WebApi.Data;
using WebApi.Data.Models;

namespace WebApi.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContextPool<WebApiDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(x =>
             {
                 x.Password.RequireDigit = false;
                 x.Password.RequireLowercase = false;
                 x.Password.RequireNonAlphanumeric = false;
                 x.Password.RequireUppercase = false;
                 x.Password.RequiredLength = 6;
             })
            .AddEntityFrameworkStores<WebApiDbContext>();
            return services;
        }
        public static IServiceCollection AddJwtBearerAuth(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IVideoService, VideoService>()
                .AddTransient<IPictureService, PictureService>()
                .AddTransient<IMusicService, MusicService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "My test WebApi",
                        Version = "v3.1"
                    });
            });
        
        
    }
}
