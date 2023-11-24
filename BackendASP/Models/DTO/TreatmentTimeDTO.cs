using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class TreatmentTimeDTO
    {
        public List<CalculationDTO> Calculation { get; set; } = new List<CalculationDTO>();
    }
}
