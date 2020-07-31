using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using AngularWebApi.Data.Models;

namespace AngularWebApi.Controllers.Identity
{
    public class IdentityService : IIdentityService
    {
        private delegate void AccountHandler(string msg, string email);
        private event AccountHandler Notify;
        private static bool isFirst = false;
        private string token;
        private UserManager<User> manager;
        private AppSettings settings;

        public IdentityService(UserManager<User> manager, IOptions<AppSettings> settings)
        {
            this.manager = manager;
            this.settings = settings.Value;
            Notify = (string msg, string email) =>
            {

            };
        }

        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await manager.FindByNameAsync(model.Username);
            if (user == null) return new UnauthorizedResult();
            var passwordValid = await manager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid) return new UnauthorizedResult();
            token = GenerateJwtToken(
                    user.Id,
                    user.UserName,
                    settings);
            var time = DateTime.Now;
            Notify($"You have logged into your account at " +
                $"{time.Day}.{time.Month}.{time.Year} " +
                $"{time.Hour}:{time.Minute}"
                , user.Email);
            return new LoginResponseModel() { Token = token };
        }

        private string GenerateJwtToken(string id, string userName, AppSettings settings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;
        }

        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var role = "user";
            if (isFirst) role = "admin";
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = role
            };
            var result = await manager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                Notify($"NEW ACCOUNT\ne-mail: {user.Email}\nlogin: {user.UserName}", user.Email);
                return new OkResult();
            }
            else return new BadRequestResult();
        }

        public async Task<ActionResult> ResetPassword(ChangePasswordModel model)
        {
            User user = await manager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                User newUser = (User)user.Clone();
                await manager.DeleteAsync(user);
                var result = await manager.CreateAsync(newUser, model.NewPassword);
                if (result.Succeeded) return new OkResult();
                else return new BadRequestResult();
            }
            else return new BadRequestResult();
        }
    }

}
