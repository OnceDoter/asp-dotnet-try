namespace WebApplication1.Models.Users
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class User : IdentityUser, ICloneable
    {
        public object Clone()
        {
            return new User 
            { 
                Id = this.Id,
                UserName = this.UserName, 
                Email = this.Email, 
                PhoneNumber = this.PhoneNumber 
            };
        }
    }
}

