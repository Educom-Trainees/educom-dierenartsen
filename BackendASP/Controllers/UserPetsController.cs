using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the pets of users
    /// </summary>
    [Route("api/user-pets")]
    [ApiController]
    public class UserPetsController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public UserPetsController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all user-pets
        /// </summary>
        /// <returns>200 + The user-pet</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/UserPets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPetDTO>>> GetUserPets()
        {
            if (_context.UserPets == null)
            {
                return NotFound();
            }
            var query = _context.UserPets
                    .Include(u => u.User)
                    .Include(u => u.PetType);

            List<UserPetDTO> userPets;

            userPets = await _mapper.ProjectTo<UserPetDTO>(query).ToListAsync();

            return userPets;
        }

        /// <summary>
        /// Get the user-pet details of one user-pet
        /// </summary>
        /// <param name="id">The id of the user-pet</param>
        /// <returns>the user-pet</returns>
        /// <remarks>returns 404 when the database or the user-pet was not found</remarks>
        // GET: api/UserPets/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserPetDTO>> GetUserPet(int id)
        {
            if (_context.UserPets == null)
            {
                return NotFound();
            }
            var userPet = await _mapper.ProjectTo<UserPetDTO>(_context.UserPets)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (userPet == null)
            {
                return NotFound();
            }

            return userPet;
        }

        /// <summary>
        /// Modify an user-pet
        /// </summary>
        /// <param name="id">The id of the user-pet</param>
        /// <param name="userPetDTO">The updated user-pet</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/UserPets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUserPet(int id, UserPetDTO userPetDTO)
        {
            if (id != userPetDTO.Id)
            {
                return BadRequest();
            }

            var existingUserPet = await _context.UserPets.FindAsync(id);

            if (existingUserPet == null)
            {
                return NotFound();
            }

            // Update existingUserPet properties with values from userPetDTO
            _mapper.Map(userPetDTO, existingUserPet);

            _context.Entry(existingUserPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPetExists(id))
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
        /// Create a new user-pet
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id is ignored</li>
        /// <li>name - name of animal (string)</li>
        /// <li>userId - must be an existing user's id </li>
        /// <li>type - must be an existing pet-type id</li>
        /// <li>role - can only be 0 for Guest, 1, for Employee, 2 for Admin</li>
        /// <li>appointments, vacations, pets - keep these empty</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database, user or type could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="userPetDTO">The new user-pet</param>
        /// <returns>The created user-pet on success</returns>
        // POST: api/UserPets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserPet>> PostUserPet(UserPetDTO userPetDTO)
        {
            if (_context.UserPets == null)
            {
                return Problem("Entity set 'PetCareContext.UserPets'  is null.");
            }
            var userPet = _mapper.Map<UserPet>(userPetDTO);

            var user = await _context.Users.FindAsync(userPetDTO.UserId);
            if (user == null)
            {
                return NotFound("user is unknown");
            }
            userPet.User = user;

            var petType = await _context.PetTypes.FindAsync(userPetDTO.PetTypeId);
            if (petType == null)
            {
                return NotFound("pet-type is unknown");
            }
            userPet.PetType = petType;

            _context.UserPets.Add(userPet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPet", new { id = userPet.Id }, _mapper.Map<UserPetDTO>(userPetDTO));
        }

        /// <summary>
        /// Remove an users' pet
        /// </summary>
        /// <param name="id">The id of the user-pet</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or user-pet were not found</remarks>
        // DELETE: api/UserPets/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserPet(int id)
        {
            if (_context.UserPets == null)
            {
                return NotFound();
            }
            var userPet = await _context.UserPets.FindAsync(id);
            if (userPet == null)
            {
                return NotFound();
            }

            _context.UserPets.Remove(userPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPetExists(int id)
        {
            return (_context.UserPets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
