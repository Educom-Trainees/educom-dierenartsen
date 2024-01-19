using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the pet-types
    /// </summary>
    [Route("api/pet-types")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public PetTypesController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all pet-types
        /// </summary>
        /// <returns>200 + The pet-types</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/PetTypes
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PetTypeDTO>>> GetPetTypes()
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petTypes = await _mapper.ProjectTo<PetTypeDTO>(_context.PetTypes)
                .ToListAsync();

            return petTypes;
        }

        /// <summary>
        /// Get the pet-type details of one pet-type
        /// </summary>
        /// <param name="id">The id of the pet-type</param>
        /// <returns>the pet-type</returns>
        /// <remarks>returns 404 when the database or the appointment was not found</remarks>
        // GET: api/PetTypes/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PetTypeDTO>> GetPetTypeById(int id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petType = await _mapper.ProjectTo<PetTypeDTO>(_context.PetTypes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (petType == null)
            {
                return NotFound();
            }

            return petType;
        }

        /// <summary>
        /// Modify a pet-type
        /// </summary>
        /// <param name="id">The id of the pet-type</param>
        /// <param name="petTypeDTO">The updated pet-type</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/PetTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPetType(int id, PetTypeDTO petTypeDTO)
        {
            if (id != petTypeDTO.Id)
            {
                return BadRequest();
            }

            var existingPetType = await _context.PetTypes.FindAsync(id);

            if (existingPetType == null)
            {
                return NotFound();
            }

            // Update existingPetType properties with values from petTypeDTO
            _mapper.Map(petTypeDTO, existingPetType);

            _context.Entry(existingPetType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetTypeExists(id))
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
        /// Create a new pet-type
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id is ignored</li>
        /// <li>name - singular name of animal (string)</li>
        /// <li>plural - plural name of animal (string)</li>
        /// <li>parentId - (optional) can be used to make subcategory of animal</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="petTypeDTO">The new pet-type</param>
        /// <returns>The created pet-type on success</returns>
        // POST: api/PetTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PetType>> PostPetType(PetTypeDTO petTypeDTO)
        {
            if (_context.PetTypes == null)
            {
                return Problem("Entity set 'PetCareContext.PetTypes'  is null.");
            }
            var petType = _mapper.Map<PetType>(petTypeDTO);

            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetType", new { id = petType.Id }, _mapper.Map<PetTypeDTO>(petType));
        }

        /// <summary>
        /// Remove a pet-type
        /// </summary>
        /// <param name="id">The id of the pet-type</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or pet-type were not found</remarks>
        // DELETE: api/PetTypes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePetType(int id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }

            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetTypeExists(int id)
        {
            return (_context.PetTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
