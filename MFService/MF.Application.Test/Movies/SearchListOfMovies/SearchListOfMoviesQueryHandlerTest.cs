using MF.Application.Interfaces;
using MF.Application.Movies.dtos;
using MF.Application.Movies.Queries.SearchListOfMovies;
using MF.Domain.Movie;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MF.Application.Test.Movies.SearchListOfMovies
{
    public class SearchListOfMoviesQueryHandlerTest
    {
        private readonly Mock<IMovieService> mockService;
        private readonly Mock<IConfiguration> mockConfigs;
        private readonly SearchListOfMoviesQueryHandler handler;

        public SearchListOfMoviesQueryHandlerTest()
        {
            mockService = new Mock<IMovieService>();
            mockConfigs = new Mock<IConfiguration>();
            handler = new SearchListOfMoviesQueryHandler(mockService.Object, mockConfigs.Object);
        }

        [Fact]
        public async Task ShouldBeReturnListOfViewMovieDto()
        {

            List<MovieLite> mlist = new List<MovieLite>() { new MovieLite { ImdbID = "1", Title = "a" } };

            var searchList = new SearchDto() { Search = mlist };

            var searchFilter = new Dictionary<string, string>()
            {
                {"s",null },
                {"apikey",null }
            };

            var ratings = new List<Rating>() { new Rating { Source = "Rotten Tomatoes", Value = "80%" } };

            var movie = new Movie { Director = "c", Plot = "test", Poster = "test", Title = "a", Year = "2021", ImdbID = "1", Ratings = ratings };

            var filter = new Dictionary<string, string>()
            {
                {"i", "1" },
                {"apikey",null }
            };


            mockService.Setup(m => m.SearchListOfMoviesAsync(searchFilter)).ReturnsAsync(searchList);
            mockService.Setup(m => m.GetMovieByIdAsync(filter)).ReturnsAsync(movie);


            var results = await handler.Handle(new SearchListOfMoviesQuery(), It.IsAny<CancellationToken>());

            Assert.Equal(typeof(List<ViewMovieDto>), results.GetType());
        }
    }
}
