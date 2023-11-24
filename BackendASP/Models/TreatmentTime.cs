using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class TreatmentTime
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [JsonIgnore]
        virtual public List<AppointmentType>? AppointmentType { get; set; }

        virtual public ICollection<Calculation> Calculation { get; set; } = new List<Calculation>();
    }
}
