using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class AssessmentQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public string QuestionType { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<AssessmentOption> AssessmentOptions { get; set; }
    }
}