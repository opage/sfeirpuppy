using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sfeirapi.Models;

namespace sfeirapi.Infrastructure
{
    public class UsersContext
    {
        private readonly IMongoDatabase _database;

        public UsersContext(IOptions<SfeirApiSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client?.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> User
        {
            get
            {
                return _database?.GetCollection<User>("Users");
            }
        }
    }
}
