using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    [Route("user-pets")]
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

        // GET: api/UserPets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPet>> GetUserPet(int id)
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

            return userPet;
        }

        // PUT: api/UserPets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPet(int id, UserPet userPet)
        {
            if (id != userPet.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPet).State = EntityState.Modified;

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

        // POST: api/UserPets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
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

        // DELETE: api/UserPets/5
        [HttpDelete("{id}")]
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
