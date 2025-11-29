using LostItems.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostItems.API.Interfaces.Repositories
{
    public interface IReturnedItemRepository
    {
        Task AddAsync(ReturnedItem ret);
        Task<List<ReturnedItem>> GetAllAsync();
    }
}
