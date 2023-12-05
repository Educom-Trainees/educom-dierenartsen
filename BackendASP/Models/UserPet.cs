namespace BackendASP.Models
{
    public class UserPet
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public required User User { get; set; }
        public required PetType PetType { get; set; }

    }
}
