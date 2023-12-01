using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using AutoMapper;

namespace BackendASP.Controllers
{
    [Route("appointment-types")]
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

        // GET: api/AppointmentTypes
        [HttpGet]
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

        // GET: api/AppointmentTypes/5
        [HttpGet("{id}")]
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

        // PUT: api/AppointmentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentType(int id, AppointmentType appointmentType)
        {
            if (id != appointmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointmentType).State = EntityState.Modified;

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

        // POST: api/AppointmentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentType appointmentType)
        {
          if (_context.AppointmentTypes == null)
          {
              return Problem("Entity set 'PetCareContext.AppointmentTypes'  is null.");
          }
            _context.AppointmentTypes.Add(appointmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentType", new { id = appointmentType.Id }, appointmentType);
        }

        // DELETE: api/AppointmentTypes/5
        [HttpDelete("{id}")]
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
