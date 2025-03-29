using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class TimeOffRequest
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string StaffId { get; set; }

        [Required]
        public string TherapistId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string RequestStatus { get; set; }

        public string Reason { get; set; }

        [Required]
        public DateTime RequestedAt { get; set; }

        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedAt { get; set; }

        // Navigation properties
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        [ForeignKey("TherapistId")]
        public virtual Therapist Therapist { get; set; }

        [ForeignKey("ApprovedBy")]
        public virtual Staff ApprovedByStaff { get; set; }
    }
}
