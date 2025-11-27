using LostItems.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostItems.API.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
    }
}
