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

            CreateMap<AppointmentType, AppointmentTypeDTO>();
            CreateMap<AppointmentTypeDTO, AppointmentType>();

            CreateMap<TreatmentTime, TreatmentTimeDTO>();
            CreateMap<TreatmentTimeDTO, TreatmentTime>();

            CreateMap<Calculation, CalculationDTO>();
            CreateMap<CalculationDTO, Calculation>();

            CreateMap<TimeSlot, TimeSlotDTO>();
            CreateMap<TimeSlotDTO, TimeSlot>();

            CreateMap<Vacation, VacationDTO>();
            CreateMap<VacationDTO, Vacation>();

            // Flattens AppointmentType>TreatmentTime>Calculation
            CreateMap<AppointmentType, AppointmentTypeDTO>()
               .ForMember(dest => dest.Calculation, opt => opt.MapFrom(src => src.TreatmentTime.Calculation));

            CreateMap<TreatmentTime, TreatmentTimeDTO>()
                .ForMember(dest => dest.Calculation, opt => opt.MapFrom(src => src.Calculation));

            CreateMap<Calculation, CalculationDTO>();


        }
    }
}
