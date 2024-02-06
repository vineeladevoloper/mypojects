using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.ComponentModel.DataAnnotations;
using taskmanagement2.DTOS;
using taskmanagement2.Irepos;

namespace taskmanagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuser _userService;
        private readonly IConfiguration _configuration;

        public UserController(Iuser userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public IActionResult GetUserById(long userId)
        {
            var user = _userService.GetUserById(userId);

            if (user != null)
                return Ok(user);
            else
                return NotFound($"User with ID {userId} not found.");
        }

        //[HttpGet("email/{email}")]
        //[Authorize]
        //public IActionResult GetUserByEmail(string email)
        //{
        //    var user = _userService.GetUserByEmail(email);

        //    if (user != null)
        //        return Ok(user);
        //    else
        //        return NotFound($"User with email {email} not found.");
        //}

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.AddUser(userDTO);
                return CreatedAtAction(nameof(GetUserById), new { userId = userDTO.Id }, userDTO);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            // Authenticate user (you may need to implement your own authentication logic here)
            var user = _userService.GetUserById(loginDTO.UserId);

            if (user == null || user.Password != loginDTO.Password)
                return Unauthorized("Invalid credentials");

            // Create JWT token
            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpPut("{userId}")]
        [Authorize]
        public IActionResult UpdateUser(long userId, [FromBody] UserDTO userDTO)
        {
            try
            {
                userDTO.Id = userId; // Ensure the ID in the URL matches the ID in the body
                _userService.UpdateUser(userDTO);
                return Ok(userDTO);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public IActionResult DeleteUser(long userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        private string GenerateJwtToken(UserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                // Add additional claims as needed
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
