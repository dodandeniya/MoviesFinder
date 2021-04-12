using MF.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MF.Infrastructure
{
    public static class Configurations
    {
        public static void AddInfraConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieService, MovieService.MovieService>();
        }
    }
}
