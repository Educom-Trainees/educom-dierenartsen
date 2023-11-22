using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class PetTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Plural { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ParentId { get; set; }
    }
}
