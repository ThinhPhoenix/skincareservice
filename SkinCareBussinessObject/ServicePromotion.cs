using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class ServicePromotion
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string PromotionId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        // Navigation properties
        [ForeignKey("PromotionId")]
        public virtual Promotion Promotion { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
