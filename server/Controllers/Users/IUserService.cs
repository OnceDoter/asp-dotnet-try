﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularWebApi.Controllers.Identity.Models;
using AngularWebApi.Data.Models;

namespace AngularWebApi.Controllers.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<ActionResult<User>> GetUserRole(string username);
        public Task<ActionResult<bool>> Create(RegisterRequestModel model);
        public Task<ActionResult<bool>> Delete(string id);
        public Task<ActionResult> Update(string id, UpdateUserModel model);
    }
}
