using LostItems.API.Data;
using LostItems.API.Interfaces;
using LostItems.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostItems.API.Repositories
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
            await _db.ReturnedItems.AddAsync(ret);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReturnedItem>> GetAllReturnedAsync()
        {
            return await _db.ReturnedItems.ToListAsync();
        }
    }
}
