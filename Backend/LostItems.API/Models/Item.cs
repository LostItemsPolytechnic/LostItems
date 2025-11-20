using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostItems.API.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)]
        public string ItemName { get; set; }

        [MaxLength(500)]
        public string ItemDescription { get; set; }

        // Foreign key to User
        [Required]
        public Guid FounderId { get; set; }

        [ForeignKey("FounderId")]
        public User Founder { get; set; }

        [MaxLength(50)]
        public string ItemStatus { get; set; }
    }
}
