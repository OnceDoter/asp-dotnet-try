using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data.Models
{
    public class User : IdentityUser, ICloneable
    {
        public IEnumerable<Video> Videos { get; } = new HashSet<Video>();
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

