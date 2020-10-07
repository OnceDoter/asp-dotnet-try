using System.Collections.Generic;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;

namespace WebApi.Controllers.Users
{
    [Authorize]
    public class UserController : ApiController
    {
        private IUserService service;
        public UserController(IUserService service)
            => this.service = service;

        [HttpGet]
        [Route(nameof(GetUsers))]
        public async Task<IEnumerable<User>> GetUsers()
            => await service.GetUsers();

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult<bool>> Delete(string id)
            => await service.Delete(id);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(string id, UpdateUserModel model)
        {
            /*User user = await service.FindByIdAsync(id);
            if (user != null)
            {
                User newUser = (User)user.Clone();
                await service.DeleteAsync(user);
                var result = await userManager
                    .CreateAsync(new User()
                    {
                        Id = id,
                        UserName = model.UserName ?? newUser.UserName,
                        PasswordHash = newUser.PasswordHash,
                        Email = model.Email ?? newUser.UserName
                    });
                if (result.Succeeded) return Ok();
                else return BadRequest(result.Errors);
            }
            else */return BadRequest();
        }
    }
    
}
