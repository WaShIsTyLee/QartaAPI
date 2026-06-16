using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QartaAPI.Data;
using QartaAPI.Entities.DTOs.RestaurantDTO;
using QartaAPI.Entities.Entities;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace QartaAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;


        public RestaurantController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("create-restaurant")]
        [Authorize]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDTO CreateRestaurantDto)
        {

            if (CreateRestaurantDto == null)
            {
                return BadRequest("Invalid restaurant data.");
            }
           
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var restaurant = new Restaurant
                {
                    Name = CreateRestaurantDto.Name,
                    Description = CreateRestaurantDto.Description,
                    Logo = CreateRestaurantDto.Logo,
                    UserId = userId
                };

                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Restaurante registrado correctamente" });

        }


        [HttpGet("get-restaurants-by-user")]
        [Authorize]
        public async Task<IActionResult> GetRestaurants()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.UserId == userId);

            if (restaurant == null)
            {
                return Ok(new { hasRestaurant = false });
            }
            return Ok(new { hasRestaurant = true, data = restaurant });

        }
    }
}
    
