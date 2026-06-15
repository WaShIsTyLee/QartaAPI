using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QartaAPI.Data;
using QartaAPI.Models.DTOs.UserDTO;
using System.Security.Claims;

namespace QartaAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;


        public UserController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDTO updateUserDto)
        {
            if (updateUserDto == null)
            {
                return BadRequest("Null UpdateUserDTO object received.");
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            if (userId == 0) return Unauthorized();

            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            
            user.Name = updateUserDto.Name ?? user.Name;
            user.Email = updateUserDto.Email ?? user.Email;
            user.ProfilePictureUrl = updateUserDto.ProfilePictureUrl ?? user.ProfilePictureUrl;

            if (updateUserDto.Password != null)
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}

