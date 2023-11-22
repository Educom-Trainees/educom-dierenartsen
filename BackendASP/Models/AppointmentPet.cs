using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendASP.Models
{
    public class AppointmentPet
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? ExtraInfo { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
    }
}
