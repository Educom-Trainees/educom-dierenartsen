using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendASP.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(PetCareContext context, IMapper mapper, IConfiguration config, IPasswordHasherService passwordHasher, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(RegisterModel registerModel)
        {
            if (registerModel == null)
            {
                return BadRequest(new { Message = "Invalid user data" });
            }

            var user = _mapper.Map<User>(registerModel);

            user.UserName = user.Email;
            user.PasswordHash = _passwordHasher.HashPassword(registerModel.Password);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                // Assign the "User" role to the registered user
                await _userManager.AddToRoleAsync(user, "GUEST");

                return Ok(new { Message = "User registered successfully" });
            }
            else
            {
                var errors = result.Errors.Select(e => new { e.Code, e.Description }).ToList();
                return BadRequest(new { Message = "User registration failed", Errors = errors });
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Your existing login logic...

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // User is authenticated successfully
                var token = GenerateJWT(user);
                GenerateCookie(token);

                // Your additional login logic...

                return Ok("Login successful");
            }

            // Authentication failed
            return BadRequest(new { Message = "Invalid username or password" });
        }

        private void GenerateCookie(string token)
        {
            Response.Cookies.Append("token", token, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true, // False only for development purposes
                SameSite = SameSiteMode.None // Adjust as needed
            });
        }

        private string GenerateJWT(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            Response.Cookies.Delete("token");

            return Ok(new { Message = "User logged out successfully" });
        }
    }
}
