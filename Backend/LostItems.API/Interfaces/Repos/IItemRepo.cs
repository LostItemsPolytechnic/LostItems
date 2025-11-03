using LostItems.API.Entities;

namespace LostItems.API.Interfaces.Repos
{
    public interface IItemRepo
    {
        Task<bool> AddItemAsync(Item item);
        Task<List<Item>> GetItemsAsync();
        Task<Item> GetItemByIdAsync(Guid id);
        Task<bool> Update(Item item);
        bool DeleteItem(Guid id);
    }
}
