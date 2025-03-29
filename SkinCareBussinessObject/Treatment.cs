using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Treatment
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string AppointmentId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Notes { get; set; }

        public string ProductsUsed { get; set; }

        public string Results { get; set; }

        public string AftercareInstructions { get; set; }

        public string FollowUpRecommendations { get; set; }

        [Required]
        public string PerformedBy { get; set; }

        // Navigation properties
        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        [ForeignKey("PerformedBy")]
        public virtual Staff PerformedByStaff { get; set; }
    }
}