using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostItems.API.Models
{
    public class ReturnedItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime RetDate { get; private set; } = DateTime.UtcNow;

        [Required]
        public Guid LosterId { get; set; }

        [ForeignKey("LosterId")]
        public User Loster { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
