using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class AppointmentHistory
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string AppointmentId { get; set; }

        [Required]
        public string PreviousStatus { get; set; }

        [Required]
        public string NewStatus { get; set; }

        [Required]
        public DateTime ChangeDateTime { get; set; }

        [Required]
        public string ChangedBy { get; set; }

        public string ChangeReason { get; set; }

        // Navigation properties
        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        [ForeignKey("ChangedBy")]
        public virtual Staff ChangedByStaff { get; set; }
    }
}
