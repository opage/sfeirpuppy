using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sfeirapi.Infrastructure.Repositories;

namespace sfeirapi.Infrastructure.Extensions
{
    public static class IoCRegistriesExtensions
    {
        public static IServiceCollection AddInfrastructureRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
