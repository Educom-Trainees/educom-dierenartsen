using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class CalculationDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Duration { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Count { get; set; }
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PetTypeId { get; set; }
    }
}
