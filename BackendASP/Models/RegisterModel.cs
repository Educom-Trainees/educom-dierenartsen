using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class RegisterModel
    {
        public required string Salutation { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        [JsonPropertyName("phone")]
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
    }
}
