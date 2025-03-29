using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SkinCareBussinessObject
{
    [Index(nameof(Email), IsUnique = true)]
    public class Account
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DOB { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }
    }
}
