using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class TherapistExpertise
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string TherapistId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public int ProficiencyLevel { get; set; }

        [Required]
        public DateTime CertificationDate { get; set; }

        // Navigation properties
        [ForeignKey("TherapistId")]
        public virtual Therapist Therapist { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
