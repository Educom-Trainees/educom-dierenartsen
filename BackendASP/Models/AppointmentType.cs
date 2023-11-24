using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class AppointmentType
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [JsonIgnore]
        virtual public List<Appointment>? Appointments { get; set; }

        public required TreatmentTime TreatmentTime { get; set; }
    }
}
