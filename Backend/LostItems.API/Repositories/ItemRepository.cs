using LostItems.API.Models;
using LostItems.API.Data;
using Microsoft.EntityFrameworkCore;
using LostItems.API.Enums;
using LostItems.API.Interfaces.Repositories;
using LostItems.API.DTOs;

namespace LostItems.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(AddItemDto item)
        {
            var itemModel = new Item
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Description = item.Description,
                ItemStatus = ItemStatusEnum.Found,
                FounderId = item.FounderId,
            };

            await _db.Items.AddAsync(itemModel);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return false;

            _db.Items.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(ItemDto itemDto)
        {
            var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == itemDto.Id);
            
            if(item == null) return false;

            _db.Items.Update(item);
            await _db.SaveChangesAsync();
            return true;
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
