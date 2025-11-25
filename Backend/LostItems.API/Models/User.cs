using LostItems.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace LostItems.API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(150), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string PasswordHash { get; set; }

        [Range(0, int.MaxValue)]
        public int NumOfFoundedItems { get; set; }

        [Range(0, int.MaxValue)]
        public int NumOfLostItems { get; set; }

        [Required]
        public RoleEnum Role { get; set; } = RoleEnum.User;
    }
}
