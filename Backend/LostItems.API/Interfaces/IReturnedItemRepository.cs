using LostItems.API.Models;

namespace LostItems.API.Interfaces
{
    public interface IReturnedItemRepository
    {
        void AddReturnedItem(ReturnedItem ret);
        IEnumerable<ReturnedItem> GetAllReturned();
    }
}
