using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Identity.Models;

namespace WebApplication1.Controllers.Identity
{
    public class IdentityController : ApiController
    {      
        private readonly IIdentityService identity;
        public IdentityController(IIdentityService identityService)
            => this.identity = identityService;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
            => await identity.Register(model);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
            => await identity.Login(model);

        [HttpPost]
        [Route(nameof(ResetPassword))]
        public async Task<ActionResult> ResetPassword(ChangePasswordModel model)
            => await identity.ResetPassword(model);



    }
}
