using BackendASP.Models.Enums;

namespace BackendASP.Models.DTO
{
    public class TimeSlotDTO
    {
        public required string Time { get; set; }
        public DoctorTypes Doctor { get; set; }
        public SlotAvailable Available { get; set; }
    }
}
