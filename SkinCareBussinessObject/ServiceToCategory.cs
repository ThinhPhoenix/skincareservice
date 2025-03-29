using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class ServiceToCategory
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public string CategoryId { get; set; }

        // Navigation properties
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}
