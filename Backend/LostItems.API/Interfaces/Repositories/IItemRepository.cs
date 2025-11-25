using LostItems.API.Enums;
using LostItems.API.Models;

namespace LostItems.API.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task AddItemAsync(Item item);
        Task<List<Item>> GetAllItemsAsync();
        Task UpdateItemStatusAsync(Guid id, ItemStatusEnum status);
    }
}
