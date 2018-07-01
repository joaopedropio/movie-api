using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    [Produces("application/json")]
    [Route("movies")]
    public class MoviesController : Controller
    {
        private MovieRepository repo;

        public MoviesController()
        {
            var connString = new Configurations().ConnectionString;
            this.repo = new MovieRepository(connString);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var movies = repo.GetAllMovies();
            return new JsonResult(movies);
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var movie = repo.GetMovieById(id);
            return new JsonResult((object)movie ?? new { });
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(int id)
        {
            var isDeleted = repo.DeleteMovieById(id);
            var status = isDeleted ? StatusCodes.Status204NoContent
                                   : StatusCodes.Status404NotFound;
            var json = new JsonResult(new { });
            json.StatusCode = status;
            return json;
        }

        [HttpPost]
        public JsonResult Insert([FromBody]Movie movie)
        {
            var isCreated = repo.InsertMovie(movie);
            var status = isCreated ? StatusCodes.Status201Created
                                   : StatusCodes.Status409Conflict;
            var json = new JsonResult(new { });
            json.StatusCode = status;
            return json;
        }
    }
}