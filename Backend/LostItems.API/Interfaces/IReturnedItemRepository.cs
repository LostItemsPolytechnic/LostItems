using LostItems.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LostItems.API.Interfaces
{
    public interface IReturnedItemRepository
    {
        Task AddReturnedItemAsync(ReturnedItem ret);
        Task<List<ReturnedItem>> GetAllReturnedAsync();
    }
}
