using System.ComponentModel.DataAnnotations;

namespace BackendASP.Models
{
    public class AppointmentPets
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? ExtraInfo { get; set; }

        public required Appointments Appointment { get; set; }
    }
}
