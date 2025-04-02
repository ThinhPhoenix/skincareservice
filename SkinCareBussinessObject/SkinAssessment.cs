using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class SkinAssessment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public DateTime AssessmentDate { get; set; }

        [Required]
        public string SkinType { get; set; }

        public string Concerns { get; set; }

        public string Allergies { get; set; }

        public string ProductsUsed { get; set; }

        public string Medications { get; set; }

        public string Recommendations { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

      
    }
}
