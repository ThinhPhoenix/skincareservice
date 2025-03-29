using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class ServiceRecommendation
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string AssessmentId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public string RecommendationStrength { get; set; }

        public string RecommendationReason { get; set; }

        // Navigation properties
        [ForeignKey("AssessmentId")]
        public virtual SkinAssessment SkinAssessment { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
