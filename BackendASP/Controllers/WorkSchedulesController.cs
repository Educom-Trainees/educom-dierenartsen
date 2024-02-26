using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using BackendASP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendASP.Controllers
{

    /// <summary>
    /// Get the time-slots
    /// </summary>
    [Route("api/work-schedules")]
    [ApiController]

    public class WorkSchedulesController : ControllerBase
    {

        private readonly IWorkScheduleService _workScheduleService;

        public WorkSchedulesController(IWorkScheduleService workScheduleService)
        {
            _workScheduleService = workScheduleService;
        }

        /// <summary>
        /// Get available days (optionally by date)
        /// </summary>
        /// <param name="date">(optional) time-slot with this specific date</param>
        /// <returns>200 + Available dayst</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/work-schedules
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkSchedule>> GetWorkSchedule([FromQuery] DateOnly? date)
        {
            WorkSchedule workSchedule = await _workScheduleService.GetWorkSchedule(date);

            return workSchedule;
        }



        // POST: WorkSchedulesController/
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        // input van onderstaande functie is de post body die in de FrontEnd is opgestuurd
        public async Task<ActionResult<WorkScheduleDTO>> UpdateWorkSchedule(WorkScheduleDTO workScheduleDTO)
        {

            WorkScheduleDTO result = await _workScheduleService.UpdateWorkSchedule(workScheduleDTO);

            return new ActionResult<WorkScheduleDTO>(result);
        }

    }
}
