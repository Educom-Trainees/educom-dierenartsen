using BackendASP.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace BackendASP.Models
{
    public class User : IdentityUser<int>
    {
        /*public int Id { get; set; }*/
        public required string Salutation { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        /*public required string Email { get; set; }
        public required string PhoneNumber {  get; set; }
        public required string PasswordHash { get; set; }*/
        public DoctorTypes Doctor { get; set; }
     /*   public virtual <IdentityUserRole<int> UserRole { get; set; }*/
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
        public virtual ICollection<UserPet> UserPets { get; set; } = new List<UserPet>();
    }
}
