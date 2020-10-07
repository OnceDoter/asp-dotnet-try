using System.Collections.Generic;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Data.Models;

namespace WebApi.Controllers.Users
{
    public class UserService : IUserService
    {
        private delegate void AccountHandler(string msg, string email);
        private event AccountHandler Notify;
        private UserManager<User> manager;
        private AppSettings settings;
        public UserService(UserManager<User> manager, IOptions<AppSettings> settings)
        {
            this.manager = manager;
            this.settings = settings.Value;
            Notify = (string msg, string email) =>
            {

            };
        }
        public async Task<ActionResult<bool>> Delete(string id)
            => (await manager.DeleteAsync(await manager.FindByIdAsync(id))).Succeeded;

        public Task<ActionResult<User>> GetUserRole(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
            => manager.Users;

        public Task<ActionResult> Update(string id, UpdateUserModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<bool>> Create(RegisterRequestModel model)
        {
            throw new System.NotImplementedException();
        }
    }

}
