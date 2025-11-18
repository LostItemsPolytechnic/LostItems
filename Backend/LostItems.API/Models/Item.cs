namespace LPNU_LostAndFound.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public int ItemFounder { get; set; }
        public string ItemStatus { get; set; }
    }
}
