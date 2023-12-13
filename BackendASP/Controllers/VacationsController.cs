using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the vacations
    /// </summary>
    [Route("api/vacations")]
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

        /// <summary>
        /// Get all vacations
        /// </summary>
        /// <returns>200 + The vacation</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/Vacations
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Get the vacation details of one vacation
        /// </summary>
        /// <param name="id">The id of the vacation</param>
        /// <returns>the vacation</returns>
        /// <remarks>returns 404 when the database or the vacation was not found</remarks>
        // GET: api/Vacations/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VacationDTO>> GetVacation(int id)
        {
            if (_context.Vacations == null)
            {
                return NotFound();
            }
            var vacation = await _mapper.ProjectTo<VacationDTO>(_context.Vacations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vacation == null)
            {
                return NotFound();
            }

            return vacation;
        }

        /// <summary>
        /// Modify a vacation
        /// </summary>
        /// <param name="id">The id of the vacation</param>
        /// <param name="vacationDTO">The updated vacation</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/Vacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVacation(int id, VacationDTO vacationDTO)
        {
            if (id != vacationDTO.Id)
            {
                return BadRequest();
            }

            var existingVacation = await _context.Vacations.FindAsync(id);

            if (existingVacation == null)
            {
                return NotFound();
            }

            // Update existingVacation properties with values from vacationDTO
            _mapper.Map(vacationDTO, existingVacation);

            _context.Entry(existingVacation).State = EntityState.Modified;

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

        /// <summary>
        /// Create a new vacation
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id is ignored</li>
        /// <li>startDateTime - (format: yyyy-mm-ddThh:mm) as starting-point vacation</li>
        /// <li>endDateTime - (format: yyyy-mm-ddThh:mm) as endpoint vacation</li>
        /// <li>reason - reason for vacation (string)</li>
        /// <li>userId - must be an existing userId</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database or user could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="vacationDTO">The new vacation</param>
        /// <returns>The created vacation on success</returns>
        // POST: api/Vacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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


        /// <summary>
        /// Remove a vacation
        /// </summary>
        /// <param name="id">The id of the vacation</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or vacation were not found</remarks>
        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
