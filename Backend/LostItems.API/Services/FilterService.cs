using LostItems.API.DTOs;
using LostItems.API.Interfaces.Services;

namespace LostItems.API.Services
{
    public class FilterService : IFilterService
    {
        public List<ItemDto> FilterByDateTime(DateTime startAt, List<ItemDto> items, DateTime? EndTime)
        {
            throw new NotImplementedException();
        }

        public List<ItemDto> GetSearchedItems(string searchInput, List<ItemDto> items)
        {
            throw new NotImplementedException();
        }
    }
}
