using AutoMapper;
using BackendASP.Models;

namespace BackendASP
{
    public class AutoMapperPet : Profile
    {
        public AutoMapperPet() {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();
            CreateMap<AppointmentPets, AppointmentPetDTO>();
            CreateMap<AppointmentPetDTO, AppointmentPets>();
        }
    }
}
