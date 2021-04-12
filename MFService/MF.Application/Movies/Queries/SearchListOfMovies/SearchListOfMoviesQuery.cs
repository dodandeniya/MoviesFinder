using MediatR;
using System.Collections.Generic;

namespace MF.Application.Movies.Queries.SearchListOfMovies
{
    public class SearchListOfMoviesQuery : IRequest<List<ViewMovieDto>>
    {
        public string Name { get; set; }
    }
}
