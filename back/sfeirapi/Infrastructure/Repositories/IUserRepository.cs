using System.Collections.Generic;
using sfeirapi.Models;

namespace sfeirapi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        int AddNewUser(User user);
        bool ModifyUser(int id, User user);
        bool Delete(int userId);

        IEnumerable<User> GetAllUsers();
    }
}
