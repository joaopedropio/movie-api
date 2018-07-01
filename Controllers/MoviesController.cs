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
        public JsonResult Index()
        {
            var movies = repo.GetAllMovies();
            return new JsonResult(movies);
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var movie = repo.GetMovieById(id);
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
    }
}