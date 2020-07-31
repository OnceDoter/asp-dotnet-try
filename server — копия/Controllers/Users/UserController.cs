using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers.Users
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route(nameof(GetUsers))]
        public async Task<IEnumerable<User>> GetUsers()
    => await identity.GetUsers();

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult<bool>> Delete(string id)
            => await identity.Delete(id);

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
                        UserName = model.UserName ?? newUser.UserName,
                        PasswordHash = newUser.PasswordHash,
                        Email = model.Email ?? newUser.UserName
                    });
                if (result.Succeeded) return Ok();
                else return BadRequest(result.Errors);
            }
            else return BadRequest();
        }
    }
    
}
