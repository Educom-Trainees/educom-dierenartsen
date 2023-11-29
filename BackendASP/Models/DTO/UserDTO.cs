using BackendASP.Models.Enums;

namespace BackendASP.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Salutation { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string PasswordHash { get; set; }
        public DoctorTypes Doctor { get; set; }
        public UserRoles Role { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<VacationDTO> Vacations { get; set; } = new List<VacationDTO>();
    }
}
