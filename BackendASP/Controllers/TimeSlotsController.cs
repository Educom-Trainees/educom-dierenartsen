using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendASP.Controllers
{
    [Route("timeslots")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public TimeSlotsController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            DayTypes days = DayTypes.WORKING_DAYS;
            DayTypes today = (DayTypes)(1 << (int)DateTime.Now.DayOfWeek);
            DayTypes monday = DayTypes.MONDAY;

            bool avaliable = (days & today) != 0;
            bool avaliable2 = (days & monday) != 0;

            int value = (int)days;
        }

        // GET: api/TimeSlots
        [HttpGet]
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

            List<TimeSlotDTO> results = new List<TimeSlotDTO>();
            int mask = 1 << (int)requestedDate.DayOfWeek;
            foreach (var timeSlot in timeSlots)
            {
                var timeslotDTO = new TimeSlotDTO
                {
                    Time = timeSlot.Time,
                    Doctor = timeSlot.Doctor,
                    Available = CalculateAvailable(timeSlot, mask),
                };
                results.Add(timeslotDTO);
            }

            return results;
        }

        private static SlotAvailable CalculateAvailable(TimeSlot timeSlot, int mask)
        {
            int days = timeSlot.AvailableDays.FirstOrDefault()?.Days ?? 0;
           
            if ((days & mask) == 0)
            {
                return SlotAvailable.NOT_AVAILABLE;
            }
            else
            {
                return SlotAvailable.AVAILABLE;
            }
        }

        // GET: api/TimeSlots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlot>> GetTimeSlot(int id)
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

            return timeSlot;
        }

        // PUT: api/TimeSlots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSlot(int id, TimeSlot timeSlot)
        {
            if (id != timeSlot.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSlot).State = EntityState.Modified;

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

        // POST: api/TimeSlots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeSlot>> PostTimeSlot(TimeSlot timeSlot)
        {
            if (_context.TimeSlots == null)
            {
                return Problem("Entity set 'PetCareContext.TimeSlots'  is null.");
            }
            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSlot", new { id = timeSlot.Id }, timeSlot);
        }

        // DELETE: api/TimeSlots/5
        [HttpDelete("{id}")]
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
