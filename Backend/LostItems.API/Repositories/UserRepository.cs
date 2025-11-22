using LostItems.API.Interfaces;
using LostItems.API.Models;
using LostItems.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LostItems.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}


