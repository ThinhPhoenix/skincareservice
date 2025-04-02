using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class Appointment
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string TherapistId { get; set; }

        [Required]
        public string ServiceId { get; set; }
        

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public string Status { get; set; }

        public string Notes { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? LastModified { get; set; }

        public string? ModifiedBy { get; set; }

        // Navigation properties
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("TherapistId")]
        public virtual Therapist Therapist { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual Staff ModifiedByStaff { get; set; }
    }
}
