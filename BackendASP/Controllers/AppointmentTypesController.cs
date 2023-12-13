using AutoMapper;
using BackendASP.Database;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the appointment-types of the veterinary
    /// </summary>
    [Route("api/appointment-types")]
    [ApiController]
    public class AppointmentTypesController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public AppointmentTypesController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of appointment-types
        /// </summary>
        /// <returns>200 + List of appointment types</returns>
        /// <remarks>returns 404 when the database was not found</remarks>
        // GET: api/AppointmentTypes
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AppointmentTypeDTO>>> GetAppointmentTypes()
        {
            if (_context.AppointmentTypes == null)
            {
                return NotFound();
            }

            var appointmentTypes = await _mapper.ProjectTo<AppointmentTypeDTO>(_context.AppointmentTypes
                  .Include(a => a.TreatmentTime)
                      .ThenInclude(t => t.Calculation))
                  .ToListAsync();

            return appointmentTypes;
        }

        /// <summary>
        /// Get an appointment-type by id
        /// </summary>
        /// <param name="id">The id of the appointment type</param>
        /// <returns>200 + Appointment type details</returns>
        /// <remarks>returns 404 when the appointment type was not found or the database was not found</remarks>
        // GET: api/AppointmentTypes/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentTypeDTO>> GetAppointmentType(int id)
        {
            if (_context.AppointmentTypes == null)
            {
                return NotFound();
            }
            var appointmentType = await _mapper.ProjectTo<AppointmentTypeDTO>(_context.AppointmentTypes
                  .Include(a => a.TreatmentTime)
                      .ThenInclude(t => t.Calculation))
                   .FirstOrDefaultAsync(a => a.Id == id);

            if (appointmentType == null)
            {
                return NotFound();
            }

            return appointmentType;
        }

        /// <summary>
        /// Modify an appointment-type
        /// </summary>
        /// <param name="id">The id of the appointment-type</param>
        /// <param name="appointmentTypeDTO">The updated appointment-type</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/AppointmentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAppointmentType(int id, AppointmentTypeDTO appointmentTypeDTO)
        {
            if (id != appointmentTypeDTO.Id)
            {
                return BadRequest();
            }

            var existingAppointmentType = await _context.AppointmentTypes.FindAsync(id);

            if (existingAppointmentType == null)
            {
                return NotFound();
            }

            // Update existingAppointmentType with values from appointmentTypeDTO
            _mapper.Map(appointmentTypeDTO, existingAppointmentType);

            _context.Entry(existingAppointmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeExists(id))
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
        /*
                // POST: api/AppointmentTypes
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                [Consumes("application/json")]
                [Produces("application/json")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                [ProducesResponseType(StatusCodes.Status404NotFound)]
                public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentTypeDTO appointmentTypeDTO)
                {
                    if (_context.AppointmentTypes == null)
                    {
                        return Problem("Entity set 'PetCareContext.AppointmentTypes'  is null.");
                    }
                    var appointmentType = _mapper.Map<AppointmentType>(appointmentTypeDTO);

                    _context.AppointmentTypes.Add(appointmentType);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetAppointmentType", new { id = appointmentType.Id },_mapper.Map<AppointmentTypeDTO>(appointmentType));
                }*/

        /// <summary>
        /// Remove an appointment-type
        /// </summary>
        /// <param name="id">The id of the appointment-type</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or appointment-type were not found</remarks>
        // DELETE: api/AppointmentTypes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAppointmentType(int id)
        {
            if (_context.AppointmentTypes == null)
            {
                return NotFound();
            }
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentTypeExists(int id)
        {
            return (_context.AppointmentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
