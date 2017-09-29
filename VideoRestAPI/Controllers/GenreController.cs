using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRestAPI.Controllers
{
    using VideoMenuAppBLL;
    using VideoMenuAppBLL.BusinessObjects;

    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<GenreBO> Get()
        {
            return this.facade.GetGenreService().GetAllGenres();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public GenreBO Get(int id)
        {
            return this.facade.GetGenreService().GetById(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]GenreBO genre)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            return this.Ok(this.facade.GetGenreService().CreateGenre(genre));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GenreBO genre)
        {
            if (id != genre.Id)
            {
                return this.BadRequest("It is shit");
            }
            try
            {
                var genreUpdate = this.facade.GetGenreService().UpdateGenre(genre);
                return this.Ok(genreUpdate);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.facade.GetGenreService().DeleteGenre(id);
        }
    }
}
