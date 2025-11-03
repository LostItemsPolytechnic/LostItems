namespace LostItems.API.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public Item(string name, string description, string imgUrl)
        {
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
        }
    }
}
