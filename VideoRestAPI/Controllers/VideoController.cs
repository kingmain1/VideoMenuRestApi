using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoRestAPI.Controllers
{
    using VideoMenuAppBLL;
    using VideoMenuAppBLL.BusinessObjects;

    [Produces("application/json")]
    [Route("api/video")]
    public class VideoController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Video
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return this.facade.GetVideoService().GetAllVideos();
        }

        // GET: api/Video/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return this.facade.GetVideoService().GetById(id);
        }

        // POST: api/Video
        [HttpPost]
        public IActionResult Post([FromBody] VideoBO video)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            return this.Ok(this.facade.GetVideoService().CreateVideo(video));
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VideoBO video)
        {
            if (id != video.Id)
            {
                return StatusCode(405, "Not the same ID");
            }

            try
            {
                return Ok(this.facade.GetVideoService().UpdateVideo(video));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.facade.GetVideoService().DeleteVideo(id);
        }
    }
}