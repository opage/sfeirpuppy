using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using sfeirapi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace sfeirapi.Infrastructure
{
    public class UsersContextSeed
    {
        private static UsersContext ctx;
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory)
        {
            var config = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<SfeirApiSettings>>();

            ctx = new UsersContext(config);
            if (!ctx.User.Database.GetCollection<User>(nameof(User)).AsQueryable().Any())
            {

            }
        }
    }
}
