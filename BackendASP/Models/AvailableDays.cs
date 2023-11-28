using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class AvailableDays
    {
        public int Id { get; set; }
        [JsonIgnore]
        public TimeSlot TimeSlot { get; set; } = null!;
        public int Days { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set;}
    }
}
        