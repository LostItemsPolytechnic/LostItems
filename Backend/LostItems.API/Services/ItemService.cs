using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostItems.API.Data;
using LostItems.API.DTOs;
using LostItems.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LostItems.API.Services
{
    public class ItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateAsync(AddItemDto dto, Guid founderId)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                ItemName = dto.Name,
                ItemDescription = dto.Description,
                Building = dto.Building,
                ItemStatus = Enums.ItemStatusEnum.Found,
                IsReturned = false,
                FounderId = founderId
            };

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items
                .Include(i => i.Founder)
                .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await _context.Items
                .Include(i => i.Founder)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item?> UpdateAsync(Guid id, AddItemDto dto)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return null;

            item.ItemName = dto.Name;
            item.ItemDescription = dto.Description;
            item.Building = dto.Building;

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return false;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkReturnedAsync(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return false;

            item.IsReturned = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
