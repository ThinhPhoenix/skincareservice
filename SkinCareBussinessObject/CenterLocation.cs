using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class CenterLocation
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        public TimeSpan ClosingTime { get; set; }

        [Required]
        public string ManagerId { get; set; }

        // Navigation property
        [ForeignKey("ManagerId")]
        public virtual Staff Manager { get; set; }
    }
}
