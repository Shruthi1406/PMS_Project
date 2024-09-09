using System.ComponentModel.DataAnnotations;

namespace PMS.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string HospitalName { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

}
