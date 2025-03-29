using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class WorkingSchedule
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string StaffId { get; set; }

        [Required]
        public string TherapistId { get; set; }

        [Required]
        public string LocationId { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public string Notes { get; set; }

        [Required]
        public string ScheduleType { get; set; }

        // Navigation properties
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        [ForeignKey("TherapistId")]
        public virtual Therapist Therapist { get; set; }

        [ForeignKey("LocationId")]
        public virtual CenterLocation CenterLocation { get; set; }
    }
}
