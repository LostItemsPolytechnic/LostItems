using LostItems.API.Data;
using LostItems.API.Interfaces.Repositories;
using LostItems.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LostItems.API.Repositories
{
    public class ReturnedItemRepository : IReturnedItemRepository
    {
        private readonly AppDbContext _db;

        public ReturnedItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ReturnedItem ret)
        {
            ret.Id = Guid.NewGuid();
            await _db.ReturnedItems.AddAsync(ret);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReturnedItem>> GetAllAsync()
        {
            return await _db.ReturnedItems.ToListAsync();
        }
    }
}
