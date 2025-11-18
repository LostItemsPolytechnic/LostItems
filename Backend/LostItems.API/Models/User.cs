using System.ComponentModel.DataAnnotations;

namespace LostItems.API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string LpnuEmail { get; set; }
    }
}
