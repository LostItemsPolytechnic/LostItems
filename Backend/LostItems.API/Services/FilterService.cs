using LostItems.API.DTOs;
using LostItems.API.Interfaces.Services;
using LostItems.API.Models;

namespace LostItems.API.Services
{
    public class FilterService : IFilterService
    {
        public List<Item> FilterByDateTime(DateTime startAt, List<Item> items, DateTime? endTime)
        {
            var filtered = items.Where(i => i.FoundDate >= startAt);

            if (endTime.HasValue)
            {
                filtered = filtered.Where(i => i.FoundDate <= endTime.Value);
            }

            return filtered.ToList();
        }

        public List<Item> GetSearchedItems(string searchInput, List<Item> items)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
                return items;

            searchInput = searchInput.ToLower();

            var filtered = items.Where(item =>
                item.Name.ToLower().Contains(searchInput) ||
                item.Description.ToLower().Contains(searchInput)
            );

            return filtered.ToList();
        }
    }
}
