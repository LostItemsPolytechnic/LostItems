using LostItems.API.Models;
using LostItems.API.Data;
using Microsoft.EntityFrameworkCore;
using LostItems.API.Enums;
using LostItems.API.Interfaces.Repositories;

namespace LostItems.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddItemAsync(Item item)
        {
            item.Id = Guid.NewGuid();
            await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task UpdateItemStatusAsync(Guid id, ItemStatusEnum newStatus)
        {
            var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return;

            item.ItemStatus = newStatus;
            await _db.SaveChangesAsync();
        }
    }
}
