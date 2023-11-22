using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class PetType
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string Plural { get; set; }
        [MaxLength(30)]
        public string? Image { get; set; }

        public PetType? Parent { get; set; }

        [JsonIgnore]
        virtual public List<Appointment>? Appointments {  get; set; }
    }
}
