using LostItems.API.DTOs;
using LostItems.API.Interfaces.Services;

namespace LostItems.API.Services
{
    public class FilterService : IFilterService
    {
        private readonly List<ItemDto> _items = new List<ItemDto>
        {
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Name = "Рюкзак",
                Description = "Чорний рюкзак з логотипом КПІ, знайдений біля корпусу №7",
                ImgUrl = "https://example.com/images/bag.jpg",
                FoundTime = DateTime.Now.AddDays(-2)
            },
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Name = "Телефон Samsung",
                Description = "Сірий Samsung Galaxy, знайдений у студентській їдальні",
                ImgUrl = "https://example.com/images/phone.jpg",
                FoundTime = DateTime.Now.AddDays(-1)
            },
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Name = "Ключі",
                Description = "Зв’язка з трьома ключами та брелком КПІ",
                ImgUrl = "https://example.com/images/keys.jpg",
                FoundTime = DateTime.Now.AddDays(-5)
            },
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Name = "Калькулятор",
                Description = "На корпусі напис 'Іван Петров'. Знайдений в аудиторії 214",
                ImgUrl = "https://example.com/images/calculator.jpg",
                FoundTime = DateTime.Now.AddDays(-3)
            }
        };

        public List<ItemDto> FilterByDateTime(DateTime startAt, List<ItemDto> items, DateTime? endTime)
        {
            var filtered = items.Where(i => i.FoundTime >= startAt);

            if (endTime.HasValue)
            {
                filtered = filtered.Where(i => i.FoundTime <= endTime.Value);
            }

            return filtered.ToList();
        }

        public List<ItemDto> GetSearchedItems(string searchInput, List<ItemDto> items)
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
        public List<ItemDto> FilterByBuilding(string building, List<ItemDto> items)
        {
            if (string.IsNullOrWhiteSpace(building))
                return items;

            return items
                .Where(item => item.Building != null &&
                               item.Building.Contains(building, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
