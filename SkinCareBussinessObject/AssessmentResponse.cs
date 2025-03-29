using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class AssessmentResponse
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string AssessmentId { get; set; }

        [Required]
        public string QuestionId { get; set; }

        [Required]
        public string OptionId { get; set; }

        public string ResponseText { get; set; }

        // Navigation properties
        [ForeignKey("AssessmentId")]
        public virtual SkinAssessment SkinAssessment { get; set; }

        [ForeignKey("QuestionId")]
        public virtual AssessmentQuestion AssessmentQuestion { get; set; }

        [ForeignKey("OptionId")]
        public virtual AssessmentOption AssessmentOption { get; set; }
    }
}
