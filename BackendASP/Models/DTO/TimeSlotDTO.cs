using BackendASP.Models.Enums;

namespace BackendASP.Models.DTO
{
    public class TimeSlotDTO
    {
        public int Id { get; set; }
        public required string Time { get; set; }
        public DoctorTypes Doctor { get; set; }
        public SlotAvailable Available { get; set; }

        public override string ToString()
        {
            return $"Id:{Id,2}|{Doctor.ToString().First()}_{Time}|{Available}";
        }

        public override bool Equals(object? obj)
        {
            TimeSlotDTO? other = obj as TimeSlotDTO;
            if (other == null)
            {
                return false;
            }
            return other.Id == Id && other.Time == Time && other.Doctor == Doctor && other.Available == Available;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Time.GetHashCode() + Doctor.GetHashCode() + Available.GetHashCode();
        }
    }
}
