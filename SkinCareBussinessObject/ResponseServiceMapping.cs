using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class ResponseServiceMapping
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string OptionId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public int RelevanceScore { get; set; }

        [Required]
        public bool Contraindication { get; set; }

        // Navigation properties
        [ForeignKey("OptionId")]
        public virtual AssessmentOption AssessmentOption { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
