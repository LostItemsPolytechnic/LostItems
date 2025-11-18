using LostItems.API.Models;

namespace LostItems.API.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}
