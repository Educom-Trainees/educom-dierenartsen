using BackendASP.Models.Enums;
using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Salutation { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        [JsonPropertyName("phone")]
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public DoctorTypes Doctor { get; set; }
        public required string Role { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<VacationDTO> Vacations { get; set; } = new List<VacationDTO>();
        [JsonPropertyName("pets")]
        public List<UserPetDTO> UserPets { get; set; } = new List<UserPetDTO>();
    }

}
