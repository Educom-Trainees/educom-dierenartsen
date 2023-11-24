using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public int? Count { get; set; }
        [JsonIgnore]
        public PetType? PetType { get; set; 
        }
        [JsonIgnore]
        public TreatmentTime TreatmentTime { get; set; } = null!;
    }
}
    