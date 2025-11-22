using LostItems.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostItems.API.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
    }
}
