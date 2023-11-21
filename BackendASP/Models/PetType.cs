using System.ComponentModel.DataAnnotations;

namespace BackendASP.Models
{
    public class PetType
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string Plural { get; set; }
        [MaxLength(30)]
        public required string Image { get; set; }

        public PetType? Parent { get; set; }

        public List<Appointments>? Appointment {  get; set; }
    }
}
