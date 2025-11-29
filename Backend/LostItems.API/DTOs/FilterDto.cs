using LostItems.API.Enums;

namespace LostItems.API.DTOs
{
    public class FilterDto
    {
        public string? Input { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public ItemStatusEnum? Status { get; set; }
    }
}
