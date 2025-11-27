using LostItems.API.DTOs;
using LostItems.API.Enums;
using LostItems.API.Models;

namespace LostItems.API.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task AddAsync(AddItemDto item);
        Task<List<Item>> GetAllAsync();
        Task UpdateItemStatusAsync(Guid id, ItemStatusEnum status);
        Task<Item?> GetByIdAsync(Guid id);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<bool> UpdateAsync(ItemDto itemDto);
    }
}
