using System.Text.Json.Serialization;

namespace BackendASP.Models.DTO
{
    public class VacationDTO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Reason { get; set; } = "";
        public required int UserId { get; set; }
    }
}
