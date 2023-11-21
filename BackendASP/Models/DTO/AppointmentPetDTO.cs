using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class AppointmentPetDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ExtraInfo { get; set; }
    }
}
