using System;
using System.ComponentModel.DataAnnotations;

namespace LostItems.API.Models
{
    public class ReturnedItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LosterId { get; set; }

        public DateTime RetDate { get; set; }
    }
}
