using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AngularWebApi.Controllers.Videos.Models;
using AngularWebApi.Infrastructure;

namespace AngularWebApi.Controllers.Videos
{
    [Authorize]
    public class VideoController : ApiController
    {
        private readonly IVideoService service;
        public VideoController(IVideoService videoService) 
            => this.service = videoService;

        [HttpGet]
        [Route(nameof(VideosByUser))]
        public async Task<IEnumerable<VideoListingServiceModel>> VideosByUser()
            => await service.ByUser(User.GetId());

        [HttpGet]
        [Route(nameof(Details))]
        public async Task<ActionResult<VideoDetailsServiceModel>> Details(int id)
            => await service.Details(id);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(AddVideoRequestModel model)
            =>  Created(
                    nameof(Create),
                    await service.Create(
                        model.ImageUrl,
                        model.Description,
                        User.GetId()));

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(UpdateVideoRequestModel model)
        {
            var updated = await service.Update(
                model.Id,
                model.Description,
                User.GetId());
            if (!updated) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id, User.GetId());
            if (!deleted) return BadRequest();
           return Ok();
        }

        [HttpPut]
        [Route(nameof(Upload))]
        public async Task<ActionResult> Upload(UploadVideoRequestModel model)
        {
            var uploaded = await service.Upload(model);
            if (!uploaded)BadRequest();
            return Ok();
        }
    }
}
