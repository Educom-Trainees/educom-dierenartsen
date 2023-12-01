using BackendASP.Models.Enums;
using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public required string Time {  get; set; }
        public DoctorTypes Doctor {  get; set; }
        [JsonIgnore]
        virtual public List<Appointment>? Appointments { get; set; }
        virtual public ICollection<AvailableDays> AvailableDays { get; set; } = new List<AvailableDays>();
        public TimeSlot? PreviousTimeSlot { get; set; }
    }
}
