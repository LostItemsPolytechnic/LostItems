namespace LostItems.API.Models
{
    public class ReturnedItem
    {
        public int RetItemID { get; set; }
        public int LosterID { get; set; }
        public DateTime RetDate { get; set; }
    }
}
