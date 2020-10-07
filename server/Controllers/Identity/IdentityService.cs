using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data.Models;

namespace WebApi.Controllers.Identity
{
    public class IdentityService : IIdentityService
    {
        private delegate void AccountHandler(string msg, string email);
        private event AccountHandler Notify;

        private string token;
        private static bool isFirstUser = true;

        private UserManager<User> manager;
        private AppSettings settings;

        public IdentityService(UserManager<User> manager, IOptions<AppSettings> settings)
        {
            this.manager = manager;
            this.settings = settings.Value;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // TODO: normal sending
            try
            {
                Notify = (string msg, string email) =>
                {
                    MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
                    MailAddress to = new MailAddress(email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "PaulWebApi:)";
                    m.Body = msg;
                    m.IsBodyHtml = true;
                    
                    smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                };
            }
            catch(Exception e) 
            { 
                //e.Message; 
            }
            
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
                $"{time.Hour}:{time.Minute}", 
                user.Email);
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
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var isSucceeded =
                (await manager.CreateAsync(user, model.Password)).Succeeded &&
                (await manager.AddToRoleAsync(
                    await manager.FindByNameAsync(model.UserName), 
                    IdentityRoles.User.ToString())).Succeeded;

            if (isFirstUser) 
                await manager.AddToRoleAsync(
                    await manager.FindByNameAsync(model.UserName),
                    IdentityRoles.User.ToString());

            if (isSucceeded)
                return new OkResult();
           return new BadRequestResult();
        }

        public async Task<ActionResult> ResetPassword(ChangePasswordModel model)
        {
            User user = await manager.FindByEmailAsync(model.Email);
            if (user == null)
                return new BadRequestResult();
            User newUser = (User)user.Clone();
            await manager.DeleteAsync(user);
            var result = await manager.CreateAsync(newUser, model.NewPassword);
            if (result.Succeeded) 
                return new OkResult();
            return new BadRequestResult();
        }
    }

}
