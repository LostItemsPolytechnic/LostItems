using LostItems.API.Enums;

namespace LostItems.API.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime? FoundTime { get; set; }
        public ItemStatusEnum Status { get; set; }
        public string Building { get; set; }
    }
}
