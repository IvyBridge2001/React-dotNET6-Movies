using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MoviesAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // /api/genres
        [HttpGet("list")] // api/genres/list/
        [HttpGet("/allgenres")] // /allgenres
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await repository.GetAllGenres();
        }

        //[HttpGet("example")]
        //[HttpGet("{Id:int}/{param2=felipe}")]
        [HttpGet("{Id}")]
        public ActionResult<Genre> Get(int Id, [BindRequired] string param2)
        {
            //BindNever will not bring the value form the request
            //BindRequired maskes param obligatory
            //FromHeader,FromBody,FromQuery,FromRoute,FromService
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = repository.GetGenreById(Id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

        //IActionResult Example
        //public IActionResult IExample(int Id)
        //{
        //    if (Id == 0)
        //        return NotFound();
        //    return Ok(Id);
        //}

    }
}
