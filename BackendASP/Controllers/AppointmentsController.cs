using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    [Route("appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public AppointmentsController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

          /*  DayTypes days = DayTypes.WORKING_DAYS;
            DayTypes today = DayTypes.SUNDAY;

            bool avaliable = (days & today) != 0;

            int value = (int)days;*/

        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments()
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointments = await _mapper.ProjectTo<AppointmentDTO>(_context.Appointments
                .Include(a => a.PetType))
                .ToListAsync();

            return appointments;
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentById(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointment = await _mapper.ProjectTo<AppointmentDTO>(_context.Appointments
                .Include(a => a.PetType))
                .FirstOrDefaultAsync(a => a.Id == id);            

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointments(int id, Appointment appointments)
        {
            if (id != appointments.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointments(AppointmentDTO appointmentDTO)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'PetCareContext.Appointments' is null.");
            }
            var appointments = _mapper.Map<Appointment>(appointmentDTO);

            var petType = await _context.PetTypes.FindAsync(appointmentDTO.PetTypeId);
            if (petType == null)
            {
                return NotFound("petType is unknown");
            }
            appointments.PetType = petType;

            var appointmentType = await _context.AppointmentTypes.FindAsync(appointmentDTO.AppointmentTypeId);
            if (appointmentType == null)
            {
                return NotFound("appointmentType is unknown");
            }
            appointments.AppointmentType = appointmentType;

            appointments.AppointmentNumber = DateTime.Now.Year * 10_000; // 20230000

            _context.Appointments.Add(appointments);
            await _context.SaveChangesAsync();
            
            // Find max number
            var maxAppointment = await _context.Appointments.MaxAsync(x => x.AppointmentNumber);
            
            // update with one
            appointments.AppointmentNumber = maxAppointment + 1;
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetAppointments", new { id = appointments.Id }, _mapper.Map<AppointmentDTO>(appointments));
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointments(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentsExists(int id)
        {
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
