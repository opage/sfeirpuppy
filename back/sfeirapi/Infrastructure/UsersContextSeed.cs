using System;
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
                await ClearData();
                await SetMathieuInfos();
                await SetOlivierInfos();
            }
        }

        private static async Task ClearData()
        {
            var filter = Builders<User>.Filter.Empty;
            await ctx.User.DeleteManyAsync(filter);
        }

        private static async Task SetMathieuInfos()
        {
            var user = new User
            {
                Id = GetNewId(),
                FirstName = "Mathieu",
                LastName = "Debon de Beauregard",
                Phone = "07.54.34.34.12",
                Adress = "46 rue Jacques Dulud",
                City = "Neuilly-sur-seine",
                CP = 92200,
                Email = "debon.m@sfeir.com",
                Birthday = new DateTime(1986, 08, 12),
                LastModified = DateTime.Now
            };
            await ctx.User.InsertOneAsync(user);
        }

        private static async Task SetOlivierInfos()
        {
            var user = new User
            {
                Id = GetNewId(),
                FirstName = "Olivier",
                LastName = "Page",
                Phone = "07.54.34.34.12",
                Adress = "46 rue Jacques Dulud",
                City = "Neuilly-sur-seine",
                CP = 92200,
                Email = "page.o@sfeir.com",
                Birthday = new DateTime(1984, 08, 12),
                LastModified = DateTime.Now
            };
            await ctx.User.InsertOneAsync(user);
        }

        private static long GetNewId()
        {
            var filter = Builders<User>.Filter.Empty;
            return ctx.User.CountDocuments(filter) + 1;
        }
    }
}
