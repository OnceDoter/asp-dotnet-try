using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers.Identity.Models;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Users
{
    public class UserService : IUserService
    {
        public Task<ActionResult<bool>> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<User>> GetUserRole(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult> Update(string id, UpdateUserModel model)
        {
            throw new System.NotImplementedException();
        }
    }

}
