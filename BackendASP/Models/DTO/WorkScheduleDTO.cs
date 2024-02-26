using BackendASP.Models.Enums;
using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class WorkScheduleDTO
    {
        [JsonPropertyName("doctorId")]
        public DoctorTypes Doctor { get; set; }

        [JsonPropertyName("startDate")]
        public DateOnly StartDate { get; set; }

        [JsonPropertyName("schedule")]
        public object Schedule {  get; set; }

    }
}
