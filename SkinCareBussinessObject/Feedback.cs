using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Feedback
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string AppointmentId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string TherapistId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comments { get; set; }

        [Required]
        public DateTime SubmittedAt { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public bool IsAddressed { get; set; }

        public string StaffResponse { get; set; }

        public DateTime? ResponseDateTime { get; set; }

        // Navigation properties
        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("TherapistId")]
        public virtual Therapist Therapist { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}