using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers.Identity.Models;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<ActionResult<User>> GetUserRole(string username);
        public Task<ActionResult<bool>> Delete(string id);
        public Task<ActionResult> Update(string id, UpdateUserModel model);
    }
}
