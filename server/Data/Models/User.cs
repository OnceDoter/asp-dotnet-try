using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Data.Models
{
    public class User : IdentityUser, ICloneable
    {
        public IEnumerable<Video> Videos { get; } = new HashSet<Video>();
        public IEnumerable<Audio> Audios { get; } = new HashSet<Audio>();
        public IEnumerable<Image> Pictures { get; } = new HashSet<Image>();
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

