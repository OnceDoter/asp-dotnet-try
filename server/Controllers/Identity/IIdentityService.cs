using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;

namespace AngularWebApi.Controllers.Identity
{
    public interface IIdentityService
    {
        public Task<ActionResult> Register(RegisterRequestModel model);
        public Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model);
        public Task<ActionResult> ResetPassword(ChangePasswordModel model);
    }
}
