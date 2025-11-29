using LostItems.API.Enums;

namespace LostItems.API.DTOs
{
    public class ListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatusEnum Status { get; set; }
    }
}
