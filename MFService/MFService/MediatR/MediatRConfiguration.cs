using MediatR;
using MF.Application.Movies.Queries.SearchListOfMovies;
using Microsoft.Extensions.DependencyInjection;

namespace MFService.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(SearchListOfMoviesQueryHandler)
            );
        }
    }
}
