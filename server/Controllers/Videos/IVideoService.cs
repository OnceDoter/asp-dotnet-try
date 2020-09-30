using System.Collections.Generic;
using AngularWebApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApi.Controllers.Videos
{
    public interface IVideoService
    {
        public ActionResult Create(Video video);

        public ActionResult Update(Video video);

        public ActionResult Delete(int id);
        public IEnumerable<Video> GetVideos();
        public IEnumerable<Video> ByUser(string userId);

    }
}
