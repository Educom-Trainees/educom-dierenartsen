

using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BackendASP.Services
{

    //Hier moet een lijst met available days komen, 
    //daar kan ik de informatie uit halen. Ik heb hier geen context nodig

    public interface IWorkScheduleService
    {
        public Task<WorkSchedule> GetWorkSchedule(DateOnly? date);

        public Task<WorkScheduleDTO> UpdateWorkSchedule(WorkScheduleDTO workScheduleDTO);
    }


    public class WorkScheduleService : IWorkScheduleService
    {
        public async Task<WorkSchedule> GetWorkSchedule(DateOnly? date)
        {
            WorkSchedule workSchedule = new WorkSchedule();

            return workSchedule;
        }

        public async Task<WorkScheduleDTO> UpdateWorkSchedule(WorkScheduleDTO workScheduleDTO)
        {

            //hier nog logica schrijven

            return workScheduleDTO;
        }
    }
}

