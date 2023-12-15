using BackendASP.Models.Enums;
using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class AppointmentPatchDTO
    {
        [JsonPropertyName("time")]
        public string? TimeSlotTime { get; set; }
        public DateOnly? Date { get; set; }
        public DoctorTypes? Doctor { get; set; }
    }
}
