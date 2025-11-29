using LostItems.API.DTOs;
using LostItems.API.Models;

namespace LostItems.API.Interfaces.Services
{
    public interface IFilterService
    {
        List<Item> GetSearchedItems(string searchInput, List<Item> items);
        List<Item> FilterByDateTime(DateTime startAt, List<Item> items, DateTime? endTime);
    }
}