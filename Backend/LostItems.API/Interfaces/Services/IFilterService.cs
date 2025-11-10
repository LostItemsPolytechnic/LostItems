using LostItems.API.DTOs;

namespace LostItems.API.Interfaces.Services
{
    public interface IFilterService
    {
        List<ItemDto> GetSearchedItems(string searchInput, List<ItemDto> items);
        List<ItemDto> FilterByDateTime(DateTime startAt, List<ItemDto> items, DateTime? endTime);
    }
}
