using MediatR;
using MF.Application.Movies.Queries.SearchListOfMovies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MFService.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator bus;

        public MovieController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchMovieList([FromQuery] SearchListOfMoviesQuery query)
        {
            return Ok(await bus.Send(query));
        }

    }
}
