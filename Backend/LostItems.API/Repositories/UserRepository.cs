using LostItems_LPNU.Data;
using LostItems_LPNU.Interfaces;
using LostItems_LPNU.Models;
using Microsoft.EntityFrameworkCore;

namespace LostItems_LPNU.Repositories
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

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}


