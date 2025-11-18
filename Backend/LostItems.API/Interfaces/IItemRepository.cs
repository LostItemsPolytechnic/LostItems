using LostItems.API.Models;

namespace LostItems.API.Interfaces
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        IEnumerable<Item> GetAllItems();
        void UpdateItemStatus(int id, string status);
    }
}
