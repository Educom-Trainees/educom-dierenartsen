using AutoMapper;
using BackendASP.Models;
using BackendASP.Models.DTO;

namespace BackendASP
{
    public class AutoMapperPet : Profile
    {
        public AutoMapperPet() {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();

            CreateMap<AppointmentPet, AppointmentPetDTO>();
            CreateMap<AppointmentPetDTO, AppointmentPet>();

            CreateMap<PetType, PetTypeDTO>();
            CreateMap<PetTypeDTO, PetType>();
        }
    }
}
