using LostItems_LPNU.Data;
using LostItems_LPNU.Interfaces;
using LostItems_LPNU.Models;
using Microsoft.EntityFrameworkCore;

namespace LostItems_LPNU.Repositories
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

        public async Task UpdateItemStatusAsync(Guid id, string newStatus)
        {
            var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return;

            item.ItemStatus = newStatus;
            await _db.SaveChangesAsync();
        }
    }
}
