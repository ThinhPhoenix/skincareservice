using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Service
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string Prerequisites { get; set; }

        public string Aftercare { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ServiceCategory ServiceCategory { get; set; }

    }
}
