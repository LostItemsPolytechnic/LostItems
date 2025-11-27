using LostItems.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostItems.API.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime FoundDate { get; private set; } = DateTime.UtcNow;

        [Required]
        public ItemStatusEnum ItemStatus { get; set; } = ItemStatusEnum.Found;

        [Required]
        public Guid FounderId { get; set; }

        [ForeignKey("FounderId")]
        public User Founder { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

    }
}
