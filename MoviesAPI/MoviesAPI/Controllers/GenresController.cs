using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MoviesAPI.Filters;

namespace MoviesAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet] // /api/genres
        [HttpGet("list")] // api/genres/list/
        [HttpGet("/allgenres")] // /allgenres
        [ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return await repository.GetAllGenres();
        }

        //[HttpGet("example")]
        //[HttpGet("{Id:int}/{param2=felipe}")]
        //public ActionResult<Genre> Get(int Id, [BindRequired] string param2)
        [HttpGet("{Id}")]
        public ActionResult<Genre> Get(int Id)
        {
            //BindNever will not bring the value form the request
            //BindRequired maskes param obligatory
            //FromHeader,FromBody,FromQuery,FromRoute,FromService
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //not necessary because of the apicontroller decorator
            logger.LogDebug("get by Id method executing...");
            var genre = repository.GetGenreById(Id);

            if (genre == null)
            {
                logger.LogWarning($"Genre with Id {Id} not found");
                //throw new ApplicationException();
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);

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
