    namespace BackendASP.Models.DTO
    {
        public class AppointmentTypeDTO
        {
            public int Id { get; set; }

            public required string Name { get; set; }

            public List<CalculationDTO> Calculation { get; set; } = new List<CalculationDTO>();
    }
    }
