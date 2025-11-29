using LostItems.API.Models;
using LostItems.API.Data;
using Microsoft.EntityFrameworkCore;
using LostItems.API.Interfaces.Repositories;

namespace LostItems.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}


