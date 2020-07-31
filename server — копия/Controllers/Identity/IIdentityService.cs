using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers.Identity.Models;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Identity
{
    public interface IIdentityService
    {
        public Task<ActionResult> Register(RegisterRequestModel model);
        public Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model);
        public Task<ActionResult> ResetPassword(ChangePasswordModel model);
        public string GenerateJwtToken(string userId, string userName, AppSettings appSettings);
    }
}
