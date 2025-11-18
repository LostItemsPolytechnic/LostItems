using LostItems_LPNU.Data;
using LostItems_LPNU.Interfaces;
using LostItems_LPNU.Models;
using Microsoft.EntityFrameworkCore;

namespace LostItems_LPNU.Repositories
{
    public class ReturnedItemRepository : IReturnedItemRepository
    {
        private readonly AppDbContext _db;

        public ReturnedItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddReturnedItemAsync(ReturnedItem ret)
        {
            ret.Id = Guid.NewGuid();
            ret.RetDate = DateTime.UtcNow;

            await _db.ReturnedItems.AddAsync(ret);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReturnedItem>> GetAllReturnedAsync()
        {
            return await _db.ReturnedItems.ToListAsync();
        }
    }
}

