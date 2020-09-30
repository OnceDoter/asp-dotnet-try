using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Controllers.Pictures
{
    interface IPictureService
    {
        public Task Create(Image image);

        public Task Update(Image image);

        public Task Delete(int id);

        public IEnumerable<Image> ByUser(string userId);

    }
}
