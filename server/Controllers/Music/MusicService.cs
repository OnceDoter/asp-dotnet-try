using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers.Music
{
    public class MusicService : IMusicService
    {
        public MusicService(WebApiDbContext data) {}
    }
}
