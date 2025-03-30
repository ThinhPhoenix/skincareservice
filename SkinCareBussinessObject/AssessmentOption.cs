using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    [Table("AssessmentOption")]
    public class AssessmentOption
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string QuestionId { get; set; }

        [Required]
        public string OptionText { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        // Navigation property
        [ForeignKey("QuestionId")]
        public virtual AssessmentQuestion AssessmentQuestion { get; set; }
    }
}
