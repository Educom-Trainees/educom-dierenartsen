using Microsoft.AspNetCore.WebUtilities;

namespace BackendASP.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public required string Reason { get; set; }
        public required User User { get; set; }

    }
}
