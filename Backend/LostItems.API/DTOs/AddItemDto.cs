namespace LostItems.API.DTOs
{
    public class AddItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FounderId { get; set; }
    }
}