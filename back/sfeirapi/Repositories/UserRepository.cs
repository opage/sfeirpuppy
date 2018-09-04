using System;
using System.Collections.Generic;
using sfeirapi.Models;

namespace sfeirapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int AddNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool ModifyUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
