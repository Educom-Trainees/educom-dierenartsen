using BackendASP.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        [JsonPropertyName("number")]
        public string AppointmentNumber { get; set; } = "";
        public DateOnly Date { get; set; }
        public int Duration { get; set; }
        [JsonPropertyName("customer")]
        [MaxLength(100)]
        public required string CustomerName { get; set; }
        [MaxLength(15)]
        public required string PhoneNumber { get; set; }
        [MaxLength(254)]
        public required string Email { get; set; }

        // FK's
        [JsonPropertyName("petType")]
        public required int PetTypeId { get; set; }

        public List<AppointmentPetDTO> Pets { get; set; } = new List<AppointmentPetDTO>();

        public DoctorTypes Preference { get; set; }
        public DoctorTypes Doctor { get; set; }
        public StatusTypes Status { get; set; }

    }
}
