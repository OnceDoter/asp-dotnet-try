using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Infrastructure;

namespace WebApi.Controllers.Videos
{
    [Authorize]
    public class VideoController : ApiController
    {
        private readonly IVideoService service;
        public VideoController(IVideoService videoService) 
            => this.service = videoService;

        [HttpGet]
        [Route(nameof(ByUser))]
        public IEnumerable<Video> ByUser()
            => service.ByUser(User.GetId());

        [HttpGet]
        [Route(nameof(Get))]
        public IEnumerable<Video> Get()
            => service.GetVideos();

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(Video video)
            => service.Create(video);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(Video video)
            => service.Update(video);

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
            => service.Delete(id);
    }
}
