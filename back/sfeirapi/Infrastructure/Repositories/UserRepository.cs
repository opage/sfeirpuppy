using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using sfeirapi.Models;

namespace sfeirapi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;

        public UserRepository(IOptions<SfeirApiSettings> settings)
        {
            _context = new UsersContext(settings);
        }

        public async Task<IEnumerable<User>> GetUsersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<User>.Filter.Eq(fieldName, fieldValue);
            var result = await _context.User.Find(filter).ToListAsync();
            return result;
        }

        public async Task<long> AddNewUser(User user)
        {
            var filter = Builders<User>.Filter.Empty;
            var id = _context.User.CountDocuments(filter) + 1;
            user.Id = id;
            await _context.User.InsertOneAsync(user);
            return id;
        }

        public async Task<bool> ModifyUser(int id, User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            var result = await _context.User.ReplaceOneAsync(
                filter,
                user,
                new UpdateOptions { IsUpsert = true });
            return result.IsAcknowledged;
        }

        public async Task<bool> Delete(int userId)
        {
            var filter = Builders<User>.Filter.Eq("Id", userId);
            var result = await _context.User.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.User.Find(new BsonDocument()).ToListAsync();
        }
    }
}
