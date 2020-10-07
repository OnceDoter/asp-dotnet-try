using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity
{
    public class IdentityController : ApiController
    {      
        private readonly IIdentityService service;
        public IdentityController(IIdentityService service)
            => this.service = service;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
            => await service.Register(model);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
            => await service.Login(model);

        [HttpPost]
        [Route(nameof(ResetPassword))]
        public async Task<ActionResult> ResetPassword(ChangePasswordModel model)
            => await service.ResetPassword(model);
    }
}
