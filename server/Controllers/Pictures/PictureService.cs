using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.Data.Models;

namespace WebApi.Controllers.Pictures
{
    public class PictureService : IPictureService
    {
        private readonly ContentRepository<Image> _repo;
        public PictureService(WebApiDbContext data)
            => _repo = new ContentRepository<Image>(data);
        public IEnumerable<Image> ByUser(string userId)
            => _repo.GetList().Where(i => i.UserId == userId);

        public ActionResult Create(Image image)
            => _repo.Create(image);
        public ActionResult Create(Image[] images)
            => _repo.Create(images);

        public ActionResult Delete(int id)
            => _repo.Delete(id);

        public IEnumerable<Image> GetImages()
            => _repo.GetList();

        public ActionResult Update(Image image)
            => _repo.Update(image);
    }
}
