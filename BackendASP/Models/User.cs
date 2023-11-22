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
        public string? PhoneNumber {  get; set; }
        public required string PasswordHash { get; set; }
        public UserRoles Role {  get; set; }
    }
}
