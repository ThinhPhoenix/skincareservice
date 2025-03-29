using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Promotion
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string PromotionName { get; set; }

        public string Description { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? DiscountAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        // Navigation property
        [ForeignKey("CreatedBy")]
        public virtual Staff CreatedByStaff { get; set; }
    }
}
