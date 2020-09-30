using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Controllers.Pictures
{
    public class PictureService : IPictureService
    {
        public IEnumerable<Image> ByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Create(Image image)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
