using System.ComponentModel.DataAnnotations;

namespace BackendASP.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public int AppointmentNumber { get; set; }
        public DateOnly Date { get; set; }
        [MaxLength(100)]
        public required string CustomerName { get; set; }
        [MaxLength(15)]
        public required string PhoneNumber { get; set; }
        [MaxLength(254)]
        public required string Email { get; set; }
        public int Preference { get; set; }
        public int Status { get; set; }

        // FK's
        public PetType? PetType { get; set; }
    }
}
