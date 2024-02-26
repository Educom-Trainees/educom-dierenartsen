

namespace BackendASP.Models
{
    public class WorkSchedule
    {
        //dit is wat terug gegeven moet gaan worden aan de front-end

        public int DoctorId { get; set; }
        public string StartDate { get; set; }
        public List<WorkDays> WorkDays { get; set; }

    }
}
