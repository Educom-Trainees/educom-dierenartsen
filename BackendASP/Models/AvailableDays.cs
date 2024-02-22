using System.Text;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"AD[{StartDate.ToShortDateString()}-{(EndDate == null ? "no end yet." : EndDate.Value.ToShortDateString())}] ");
            if ((Days & (1 << (int)DayOfWeek.Sunday)) != 0) { sb.Append("Sun, "); }
            if ((Days & (1 << (int)DayOfWeek.Monday)) != 0) { sb.Append("Mon,"); }
            if ((Days & (1 << (int)DayOfWeek.Tuesday)) != 0) { sb.Append("Tue,"); }
            if ((Days & (1 << (int)DayOfWeek.Wednesday)) != 0) { sb.Append("Wed,"); }
            if ((Days & (1 << (int)DayOfWeek.Thursday)) != 0) { sb.Append("Thu,"); }
            if ((Days & (1 << (int)DayOfWeek.Friday)) != 0) { sb.Append("Fri,"); }
            if ((Days & (1 << (int)DayOfWeek.Saturday)) != 0) { sb.Append("Sat,"); }
            return sb.ToString();
        }
    }
}
        