using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the time-slots
    /// </summary>
    [Route("api/time-slots")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public TimeSlotsController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all time-slots
        /// </summary>
        /// <param name="date">(optional) time-slot with this specific date</param>
        /// <returns>200 + The time-slot</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/TimeSlots
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetTimeSlots([FromQuery] DateOnly? date)
        {
            if (_context.TimeSlots == null)
            {
                return NotFound();
            }
            var requestedDate = date ?? DateOnly.FromDateTime(DateTime.Now);
            var timeSlots = await _context.TimeSlots
                .Include(t => t.AvailableDays.Where(d => d.StartDate <= requestedDate && (d.EndDate == null || d.EndDate > requestedDate)))
                .ToListAsync();

            var vacationsOnDate = await _context.Vacations
                .Include(v => v.User)
                .Where(v => DateOnly.FromDateTime(v.StartDateTime) <= requestedDate && DateOnly.FromDateTime(v.EndDateTime) >= requestedDate)
                .ToListAsync();

            var bookedAppointments = await _context.Appointments.Include(a => a.TimeSlots)
                .Where(a => a.Date == requestedDate && a.Status == StatusTypes.ACTIVE)
                .ToListAsync();

            List<TimeSlotDTO> results = new List<TimeSlotDTO>();
            int mask = 1 << (int)requestedDate.DayOfWeek;
            foreach (var timeSlot in timeSlots)
            {
                var appointment = bookedAppointments.FirstOrDefault(a => a.TimeSlots.Contains(timeSlot));
                var vacation = vacationsOnDate.FirstOrDefault(v => v.User.Doctor == timeSlot.Doctor);

                var timeslotDTO = new TimeSlotDTO
                {
                    Time = timeSlot.Time,
                    Doctor = timeSlot.Doctor,
                    Available = CalculateAvailable(timeSlot, mask, appointment, vacation, requestedDate),
                };
                results.Add(timeslotDTO);
            }

            return results;
        }

        private static SlotAvailable CalculateAvailable(TimeSlot timeSlot, int mask, Appointment? appointment, Vacation? vacation, DateOnly requestedDate)
        {
            int days = timeSlot.AvailableDays.FirstOrDefault()?.Days ?? 0;

            if ((days & mask) == 0)
            {
                return SlotAvailable.NOT_AVAILABLE;
            }

            TimeOnly timeSlotTime = TimeOnly.Parse(timeSlot.Time);

            if (vacation != null)
            {
                DateOnly vacationStart = DateOnly.FromDateTime(vacation.StartDateTime);
                DateOnly vacationEnd = DateOnly.FromDateTime(vacation.EndDateTime);

                if ((requestedDate >= vacationStart && requestedDate <= vacationEnd) &&
                    (requestedDate != vacationStart || timeSlotTime >= TimeOnly.FromDateTime(vacation.StartDateTime)) &&
                    (requestedDate != vacationEnd || timeSlotTime <= TimeOnly.FromDateTime(vacation.EndDateTime)))
                {
                    return SlotAvailable.VACATION;
                }
            }

            if (appointment != null)
            {
                return SlotAvailable.BOOKED;
            }

            else
            {
                TimeSlot currentSlot = timeSlot;
                for (int i = 0; i < 3; i++)
                {
                    currentSlot = currentSlot?.PreviousTimeSlot;
                    if (currentSlot?.Appointments != null && currentSlot.Appointments[0].Duration > 15 * (i + 1))
                    {
                        return SlotAvailable.BOOKED;
                    }
                }

                return SlotAvailable.AVAILABLE;
            }
        }

        /// <summary>
        /// Get the time-slot details of one time-slot
        /// </summary>
        /// <param name="id">The id of the time-slot</param>
        /// <returns>the time-slot</returns>
        /// <remarks>returns 404 when the database or the time-slot was not found</remarks>
        // GET: api/TimeSlots/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TimeSlotDTO>> GetTimeSlot(int id)
        {
            if (_context.TimeSlots == null)
            {
                return NotFound();
            }
            var timeSlot = await _mapper.ProjectTo<TimeSlotDTO>(_context.TimeSlots)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return timeSlot;
        }

        /// <summary>
        /// Modify a time-slot
        /// </summary>
        /// <param name="id">The id of the time-slot</param>
        /// <param name="timeSlotDTO">The updated time-slot</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/TimeSlots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutTimeSlot(int id, TimeSlotDTO timeSlotDTO)
        {
            if (id != timeSlotDTO.Id)
            {
                return BadRequest();
            }

            var existingTimeSlot = await _context.TimeSlots.FindAsync(id);

            if (existingTimeSlot == null)
            {
                return NotFound();
            }

            // Update existingTimeSlot properties with values from timeSlotDTO
            _mapper.Map(timeSlotDTO, existingTimeSlot);

            _context.Entry(existingTimeSlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSlotExists(id))
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

        /// <summary>
        /// Create a new time-slot
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id is ignored</li>
        /// <li>time - (format: hh:mm) string</li>
        /// <li>doctor - can only be 1 for Karel, 2 for Danique or 3 for both</li>
        /// <li>available - can only be 0 for Not_Available, 1 for Available, 2 for Booked or 3 for Vacation</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="timeSlotDTO">The new time-slot</param>
        /// <returns>The created time-slot on success</returns>
        // POST: api/TimeSlots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TimeSlot>> PostTimeSlot(TimeSlotDTO timeSlotDTO)
        {
            if (_context.TimeSlots == null)
            {
                return Problem("Entity set 'PetCareContext.TimeSlots'  is null.");
            }
            var timeSlot = _mapper.Map<TimeSlot>(timeSlotDTO);

            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSlot", new { id = timeSlot.Id }, timeSlot);
        }

        /// <summary>
        /// Remove a time-slot
        /// </summary>
        /// <param name="id">The id of the time-slot</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or time-slot were not found</remarks>
        // DELETE: api/TimeSlots/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTimeSlot(int id)
        {
            if (_context.TimeSlots == null)
            {
                return NotFound();
            }
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeSlotExists(int id)
        {
            return (_context.TimeSlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
