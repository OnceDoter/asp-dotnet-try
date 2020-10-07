using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Infrastructure;

namespace WebApi.Controllers.Pictures
{
    [Authorize]
    public class PictureController : ApiController
    {
        private readonly IPictureService _service;
        public PictureController(IPictureService service)
            => this._service = service;

        [HttpGet]
        [Route(nameof(ByUser))]
        public IEnumerable<Image> ByUser()
            => _service.ByUser(User.GetId());

        [HttpGet]
        [Route(nameof(Get))]
        public IEnumerable<Image> Get()
            => _service.GetImages();

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(Image video)
            => _service.Create(video);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(Image video)
            => _service.Update(video);

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
            => _service.Delete(id);
    }
}
