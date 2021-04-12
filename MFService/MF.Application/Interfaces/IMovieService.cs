using MF.Application.Movies.dtos;
using MF.Domain.Movie;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MF.Application.Interfaces
{
    public interface IMovieService
    {
        [Get("")]
        Task<Movie> GetMovieByIdAsync([QueryMap] IDictionary<string, string> filters);

        [Get("")]
        Task<SearchDto> SearchListOfMoviesAsync([QueryMap] IDictionary<string, string> filters);
    }
}
