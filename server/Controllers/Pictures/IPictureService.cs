using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;

namespace WebApi.Controllers.Pictures
{
    public interface IPictureService
    {
        public ActionResult Create(Image image);

        public ActionResult Update(Image image);

        public ActionResult Delete(int id);
        public IEnumerable<Image> GetImages();
        public IEnumerable<Image> ByUser(string userId);

    }
}
