using System.Collections.Generic;
using System.Threading.Tasks;
using sfeirapi.Models;

namespace sfeirapi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersByField(string fieldName, object fieldValue);
        Task<long> AddNewUser(User user);
        Task<bool> ModifyUser(int id, User user);
        Task<bool> Delete(int userId);

        Task<IEnumerable<User>> GetAllUsers();
    }
}
