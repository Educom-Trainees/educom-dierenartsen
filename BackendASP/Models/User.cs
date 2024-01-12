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
        /*virtual public ICollection<IdentityUserRole<int>>? Role { get; set; }*/
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }
        virtual public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        virtual public ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
        virtual public ICollection<UserPet> UserPets { get; set; } = new List<UserPet>();
    }
}
