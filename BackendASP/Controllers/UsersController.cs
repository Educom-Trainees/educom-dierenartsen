using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Duende.IdentityServer.Extensions;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static Duende.IdentityServer.Models.IdentityResources;

namespace BackendASP.Controllers
{
    /// <summary>
    /// Get the users
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public UsersController(PetCareContext context, IMapper mapper, IEmailService emailService, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="email">(optional) user with this specific email</param>
        /// <returns>200 + The user</returns>
        /// <remarks>returns 404 on missing database</remarks>
        // GET: api/Users
        [HttpGet]
        [Authorize(Roles = "GUEST, EMPLOYEE, ADMIN")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] string? email)
        {
            if (email != null) {
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && User.IsInRole("GUEST"))
                {
                    email = currentUser.Email;
                }
            }

            var query = _context.Users
                  .Include(u => u.Vacations)
                  .Include(u => u.Appointments)
                  .Include(u => u.UserPets);

            List<UserDTO> users;
            if (email != null)
            {
                users = await _mapper.ProjectTo<UserDTO>(query.Where(u => u.Email == email)).ToListAsync();
            }
            else
            {
                users = await _mapper.ProjectTo<UserDTO>(query).ToListAsync();
            }

            return users;
        }

        /// <summary>
        /// Get the user details of one user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>the user</returns>
        /// <remarks>returns 404 when the database or the user was not found</remarks>
        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Roles = "GUEST, EMPLOYEE, ADMIN")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null && User.IsInRole("GUEST"))
            {
                id = currentUser.Id;
            }

            var user = await _context.Users
                .Include(u => u.Vacations)
                .Include(u => u.Appointments)
                .Include(u => u.UserPets)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles != null)
            {
                var userDTO = _mapper.Map<UserDTO>(user);

                return userDTO;
            }
            else
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Modify an user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userDTO">The updated user</param>
        /// <returns>201 on success</returns>
        /// <remarks>returns 400 on a bad request
        /// returns 404 when the database was not found</remarks>
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "GUEST, EMPLOYEE, ADMIN")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update existingUser properties with values from userDTO
            _mapper.Map(userDTO, existingUser);

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /// Create a new user
        /// </summary>
        /// <remarks>        
        /// <ul>
        /// <li>id is ignored</li>
        /// <li>salutation, firstName, lastName, email, phone - all strings</li>
        /// <li>passwordHash - encrypted password string</li>
        /// <li>doctor - can only be 1 for Karel, 2 for Danique or 3 for both</li>
        /// <li>role - can only be 0 for Guest, 1, for Employee, 2 for Admin</li>
        /// <li>appointments, vacations, pets - keep these empty</li>
        /// </ul><ul>
        /// <li>returns 400 on a incorrect or incomplete request</li>
        /// <li>returns 404 when the database could not be found</li>
        /// </ul>
        /// </remarks>
        /// <param name="userDTO">The new user</param>
        /// <returns>The created user on success</returns>
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = _mapper.Map<User>(userDTO);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Send email after successfully creating a new user
            try
            {
                await _emailService.FormatAndSendEmailAsync(2, userDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, _mapper.Map<UserDTO>(user));
        }

        /// <summary>
        /// Remove an user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>204 when deleted</returns>
        /// <remarks>returns 404 when the database or user were not found</remarks>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
