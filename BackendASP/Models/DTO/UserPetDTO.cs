using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class UserPetDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int UserId { get; set; }
        [JsonPropertyName("type")]
        public required int PetTypeId { get; set; }

    }
}
