using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the appointments made by customers
    /// </summary>
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AppointmentsController(PetCareContext context, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }

        /// <summary>
        /// Get The first 100 appointments (of a certain date or state)
        /// </summary>
        /// <param name="date">(optional) appointments of this specific date</param>
        /// <param name="status">(optional) appointments that have this status (0 = active, 1 = cancelled by doctor, 2 = cancelled by customer, 3 = during vacation)</param>
        /// <param name="userId">(optional) appointments that have this userId</param>
        /// <returns>200 + The appointment</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/Appointments
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments([FromQuery] DateOnly? date, [FromQuery] StatusTypes? status, [FromQuery] int? userId)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }

            IQueryable<Appointment> query = _context.Appointments.Take(100);
            if (date != null)
            {
                query = query.Where(a => a.Date == date);
            }
            if (status != null)
            {
                query = query.Where(a => a.Status == status);
            }
            if (userId != null)
            {
                query = query.Where(a => a.User != null && a.User.Id == userId);
            }
            var appointments = await _mapper.ProjectTo<AppointmentDTO>(query).ToListAsync();

            return appointments;
        }

        /// <summary>
        /// Get the appointment details of one appointment
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <returns>the appointment</returns>
        /// <remarks>returns 404 when the database or the appointment was not found</remarks>
        // GET: api/Appointments/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentById(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointment = await _mapper.ProjectTo<AppointmentDTO>(_context.Appointments)
                                           .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        /// <summary>
        /// Modify an appointment
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <param name="patchDocument">The JSON Patch document with the updates</param>
        /// <returns>204 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PATCH: api/Appointments/5
        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchAppointment(int id, [FromBody] JsonPatchDocument<AppointmentPatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var existingAppointment = await _context.Appointments
                .Include(a => a.TimeSlots)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (existingAppointment == null)
            {
                return NotFound();
            }

            var appointmentPatchDTO = _mapper.Map<AppointmentPatchDTO>(existingAppointment);

            // Apply the patch document to the existing appointment DTO
            patchDocument.ApplyTo(appointmentPatchDTO, (patchError) =>
            {
                ModelState.AddModelError("JsonPatch", patchError.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (appointmentPatchDTO.Doctor != null)
            {
                existingAppointment.Doctor = appointmentPatchDTO.Doctor.Value;
            }

            // Validate and update the TimeSlot if specified in the patch
            if (appointmentPatchDTO.TimeSlotTime != null)
            {
                if (!await UpdateTimeSlots(appointmentPatchDTO.TimeSlotTime, existingAppointment))
                {               
                    return NotFound("time-slot is unknown");
                }
            }

            // Update other appointment properties if needed
            if (appointmentPatchDTO.Date != null)
            {
                existingAppointment.Date = appointmentPatchDTO.Date.Value;
            }


            _context.Entry(existingAppointment).State = EntityState.Modified;

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
  

        /// <summary>
        /// Modify an appointment
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <param name="appointmentDTO">The updated appointment</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAppointments(int id, AppointmentDTO appointmentDTO)
        {
            if (id != appointmentDTO.Id)
            {
                return BadRequest();
            }

            var existingAppointment = await _context.Appointments.Include(a => a.TimeSlots).FirstOrDefaultAsync(a => a.Id == id);

            if (existingAppointment == null)
            {
                return NotFound();
            }

            // Update existingAppointment properties with values from appointmentDTO
            _mapper.Map(appointmentDTO, existingAppointment);

            if (appointmentDTO.TimeSlotTime != null)
            {
                if (!await UpdateTimeSlots(appointmentDTO.TimeSlotTime, existingAppointment))
                {
                    return NotFound("time-slot is incorrect");
                }
            }
            else
            {
                return NotFound("time-slot is not entered");
            }

            _context.Entry(existingAppointment).State = EntityState.Modified;

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

        private async Task<bool> UpdateTimeSlots(string timeSlotTime, Appointment appointment)
        {
            var timeSlotsInDatabase = await _context.TimeSlots
                .Where(ts => ts.Time == timeSlotTime).ToListAsync();

            if (timeSlotsInDatabase == null || timeSlotsInDatabase.Count != 2)
            {
                return false;
            }

            appointment.TimeSlots.Clear();
            if (appointment.Doctor == DoctorTypes.BOTH)
            {
                appointment.TimeSlots.AddRange(timeSlotsInDatabase);
            }
            else
            {
                appointment.TimeSlots.Add(timeSlotsInDatabase.First(ts => ts.Doctor == appointment.Doctor));
            }

            return true;
        }

        /// <summary>
        /// Create a new appointment
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id, number, status and islatecancellation are ignored</li>
        /// <li>time - (format: hh:mm) must be an available timeslot</li>
        /// <li>date - (format: yyyy-mm-dd)</li>
        /// <li>duration - must be 15, 30, 45 or 60 (minutes)</li> 
        /// <li>userId - (optional) the id of the user when a user is logged in</li>
        /// <li>preference - can only be 0 for no-preference, 1 for Karel or 2 for Danique</li>
        /// <li>doctor - can only be 1 for Karel, 2 for Danique or 3 for both</li>
        /// <li>pet names and extraInfo are both optional, when both absent still send the object as it is needed for the count</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database, pet-type, doctor-type, type or timeslot could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="appointmentDTO">The new appointment</param>
        /// <returns>The created appointment on success</returns>
        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDTO>> PostAppointments(AppointmentDTO appointmentDTO)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'PetCareContext.Appointments' is null.");
            }
            /* DO NOT remove pets without a name or store the number of pets somewhere!
            appointmentDTO.Pets = appointmentDTO.Pets.Where(p => !string.IsNullOrEmpty(p.Name)).ToList();
            */
            var appointment = _mapper.Map<Appointment>(appointmentDTO);

            // ignore id, number, status and islatecancellation
            appointment.Id = 0;
            appointment.AppointmentNumber = 0;
            appointment.Status = StatusTypes.ACTIVE;
            appointment.LateStatus = LateStatus.NOT_LATE;
            foreach (var pet in appointment.Pets)
            {
                pet.Id = 0;
            }

            appointment.User = await _context.Users.FindAsync(appointmentDTO.UserId);

            // TODO: put this in a service or logic class
            if (appointment.Doctor == DoctorTypes.NO_PREFERENCE)
            {
                return BadRequest("Doctor cannot be 0");
            }
            if (appointment.Preference == DoctorTypes.BOTH)
            {
                return BadRequest("Preference cannot be 3");
            }

            var petType = await _context.PetTypes.FindAsync(appointmentDTO.PetTypeId);
            if (petType == null)
            {
                return NotFound("petType is unknown");
            }
            appointment.PetType = petType;

            var appointmentType = await _context.AppointmentTypes.FindAsync(appointmentDTO.AppointmentTypeId);
            if (appointmentType == null)
            {
                return NotFound("appointmentType is unknown");
            }
            appointment.AppointmentType = appointmentType;

            if (!await UpdateTimeSlots(appointmentDTO.TimeSlotTime, appointment))
            {
                return NotFound("timeSlot is unknown");
            }

            appointment.AppointmentNumber = DateTime.Now.Year * 10_000; // 20230000

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Find max number
            var maxAppointment = await _context.Appointments.MaxAsync(x => x.AppointmentNumber);

            // update with one
            appointment.AppointmentNumber = maxAppointment + 1;
            await _context.SaveChangesAsync();

            // Send email after successfully creating a new appointment

            await _emailService.SendAppointmentConfirmationEmailAsync(appointmentDTO);

            return CreatedAtAction("GetAppointments", new { id = appointment.Id }, _mapper.Map<AppointmentDTO>(appointment));
        }

        /// <summary>
        /// Remove an appointment (better is to change the status to cancelled)
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or appointment were not found</remarks>
        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
