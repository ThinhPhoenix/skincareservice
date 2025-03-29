using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Therapist
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Bio { get; set; }

        public string Expertise { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public TimeSpan WorkStartTime { get; set; }

        [Required]
        public TimeSpan WorkEndTime { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
