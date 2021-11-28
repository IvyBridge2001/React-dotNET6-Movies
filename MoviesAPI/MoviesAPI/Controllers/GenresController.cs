using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Entities;

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
        public List<Genre> Get()
        {
            return repository.GetAllGenres();
        }

        //[HttpGet("example")]
        //[HttpGet("{Id:int}/{param2=felipe}")]
        [HttpGet("{Id}")]
        public Genre Get(int Id)
        {
            var genre = repository.GetGenreById(Id);

            if (genre == null)
            {
                //return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public void Post(){}

        [HttpPut]
        public void Put() { }

        [HttpDelete]
        public void Delete() { }

    }
}
