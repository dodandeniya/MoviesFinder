using MediatR;
using MF.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MF.Application.Movies.Queries.SearchListOfMovies
{
    public class SearchListOfMoviesQueryHandler : IRequestHandler<SearchListOfMoviesQuery, List<ViewMovieDto>>
    {
        private readonly IMovieService movieService;
        private readonly IConfiguration configuration;

        public SearchListOfMoviesQueryHandler(IMovieService movieService, IConfiguration configuration)
        {
            this.movieService = movieService;
            this.configuration = configuration;
        }

        public async Task<List<ViewMovieDto>> Handle(SearchListOfMoviesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var searchFilter = new Dictionary<string, string>()
            {
                {"s",request.Name },
                {"apikey",configuration["ApiKey"] }
            };

            var movies = await movieService.SearchListOfMoviesAsync(searchFilter);

            List<ViewMovieDto> moviesList = new List<ViewMovieDto>();

            foreach (var m in movies.Search)
            {
                var filter = new Dictionary<string, string>()
                {
                    {"i",m.ImdbID },
                    {"apikey",configuration["ApiKey"]}
                };

                var movie = await movieService.GetMovieByIdAsync(filter);
                moviesList.Add(new ViewMovieDto
                {
                    Title = movie.Title,
                    Director = movie.Director,
                    Plot = movie.Plot,
                    Poster = movie.Poster,
                    Year = movie.Year,
                    RtRating = movie.Ratings.Any(r => r.Source == "Rotten Tomatoes") ? movie.Ratings.Where(r => r.Source == "Rotten Tomatoes").Select(r => r.Value).First() : "N/A",
                });
            }

            return moviesList;
        }
    }
}
