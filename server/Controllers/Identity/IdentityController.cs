namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApplication1.Controllers.Identity;
    using WebApplication1.Controllers.Users;
    using WebApplication1.Models.Identity;
    using WebApplication1.Models.Users;

    public class IdentityController : ApiController
    {
        public static bool isFirst = false;
        public static IdentityController Controller;
        public static IUserService UserService;
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly IUserService userService;
        private readonly AppSettings appSettings;
        private string Token;
        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IUserService userService,
            IOptions<AppSettings> appSettings
            )
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.userService = userService;
            this.appSettings = appSettings.Value;
            Controller = this;
            UserService = userService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            string role = "user";
            if (isFirst) role = "admin";
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = role
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) return Ok();
            else return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null) return Unauthorized();
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid) return Unauthorized();
            return new LoginResponseModel
            {
                Token = identityService.GenerateJwtToken(
                    user.Id,
                    user.UserName,
                    appSettings)
            };
        }

        [HttpPost]
        [Route(nameof(ResetPassword))]
        public async Task<ActionResult> ResetPassword(ChangePasswordModel model)
        {
            User user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                User newUser = (User)user.Clone();
                await userManager.DeleteAsync(user);
                var result = await userManager.CreateAsync(newUser, model.NewPassword);
                if (result.Succeeded) return Ok();
                else return BadRequest(result.Errors);
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route(nameof(GetUsers))]
        public async Task<IEnumerable<User>> GetUsers()
        => userManager.Users;

        [HttpGet]
        [Route(nameof(GetUserRole))]
        public async Task<ActionResult<string>> GetUserRole(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return user.PhoneNumber;
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult<bool>> Delete(string id)
            => (await userManager.DeleteAsync(await userManager.FindByIdAsync(id))).Succeeded;

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(string id, UpdateUserModel model)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                User newUser = (User)user.Clone();
                await userManager.DeleteAsync(user);
                var result = await userManager
                    .CreateAsync(new User()
                    {
                        Id = id,
                        UserName = (model.UserName == null) ? newUser.UserName : model.UserName,
                        PasswordHash = newUser.PasswordHash,
                        Email = (model.Email == null) ? newUser.UserName : model.Email
                    });
                if (result.Succeeded) return Ok();
                else return BadRequest(result.Errors);
            }
            else return BadRequest();
        }

    }
}
