using System;

namespace LPNU_LostAndFound.Models
{
    public class ReturnedItem
    {
        public int RetItemID { get; set; }
        public int LosterID { get; set; }
        public DateTime RetDate { get; set; }
    }
}
