using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    [Route("vacations")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public VacationsController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Vacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacationDTO>>> GetVacations()
        {
            if (_context.Vacations == null)
            {
                return NotFound();
            }
            var vacation = await _mapper.ProjectTo<VacationDTO>(_context.Vacations)
                  .ToListAsync();

            return vacation;
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacation>> GetVacation(int id)
        {
            if (_context.Vacations == null)
            {
                return NotFound();
            }
            var vacation = await _context.Vacations.FindAsync(id);

            if (vacation == null)
            {
                return NotFound();
            }

            return vacation;
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacation(int id, Vacation vacation)
        {
            if (id != vacation.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
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

        // POST: api/Vacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacation>> PostVacation(VacationDTO vacationDTO)
        {
            if (_context.Vacations == null)
            {
                return Problem("Entity set 'PetCareContext.Vacations'  is null.");
            }
            var vacation = _mapper.Map<Vacation>(vacationDTO);

            var user = await _context.Users.FindAsync(vacationDTO.UserId);
            if (user == null)
            {
                return NotFound("user is unknown");
            }
            vacation.User = user;


            _context.Vacations.Add(vacation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacation", new { id = vacation.Id }, _mapper.Map<VacationDTO>(vacation)); ;
        }


        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacation(int id)
        {
            if (_context.Vacations == null)
            {
                return NotFound();
            }
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacationExists(int id)
        {
            return (_context.Vacations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
