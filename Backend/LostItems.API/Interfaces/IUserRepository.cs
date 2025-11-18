using LPNU_LostAndFound.Models;
using System.Collections.Generic;

namespace LPNU_LostAndFound.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}
