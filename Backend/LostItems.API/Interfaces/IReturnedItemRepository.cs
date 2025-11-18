using LPNU_LostAndFound.Models;
using System.Collections.Generic;

namespace LPNU_LostAndFound.Interfaces
{
    public interface IReturnedItemRepository
    {
        void AddReturnedItem(ReturnedItem ret);
        IEnumerable<ReturnedItem> GetAllReturned();
    }
}
