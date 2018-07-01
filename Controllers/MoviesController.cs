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
        public IActionResult GetById(int id)
        {
            var movie = repo.GetMovieById(id);
            if (movie == null)
            {
                return new StatusCodeResult(404);
            }

            return new JsonResult(movie);
        }

        [HttpDelete("{id}")]
        public StatusCodeResult DeleteById(int id)
        {
            var isDeleted = repo.DeleteMovieById(id);
            var status = isDeleted ? StatusCodes.Status204NoContent
                                   : StatusCodes.Status404NotFound;
            return new StatusCodeResult(status);
        }

        [HttpPost]
        public StatusCodeResult Insert([FromBody]Movie movie)
        {
            var isCreated = repo.InsertMovie(movie);
            var status = isCreated ? StatusCodes.Status201Created
                                   : StatusCodes.Status409Conflict;
            return new StatusCodeResult(status);
        }
    }
}