using MF.Application.Interfaces;
using MF.Application.Movies.dtos;
using MF.Domain.Movie;
using Microsoft.Extensions.Configuration;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MF.Infrastructure.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieService client;

        public MovieService(IConfiguration configuration)
        {
            client = RestClient.For<IMovieService>(configuration["OmdbapiURL"]);
        }

        public async Task<SearchDto> SearchListOfMoviesAsync([QueryMap] IDictionary<string, string> filters)
        {
            return await client.SearchListOfMoviesAsync(filters);
        }

        public async Task<Movie> GetMovieByIdAsync([QueryMap] IDictionary<string, string> filters)
        {
            return await client.GetMovieByIdAsync(filters);
        }
    }
}
