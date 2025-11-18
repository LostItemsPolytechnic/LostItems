using LPNU_LostAndFound.Models;
using System.Collections.Generic;

namespace LPNU_LostAndFound.Interfaces
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        IEnumerable<Item> GetAllItems();
        void UpdateItemStatus(int id, string status);
    }
}
