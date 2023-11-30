using BackendASP.Models.Enums;

namespace BackendASP.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Salutation { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber {  get; set; }
        public required string PasswordHash { get; set; }
        public DoctorTypes Doctor { get; set; }
        public UserRoles Role {  get; set; }
        virtual public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        virtual public ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
    }
}
