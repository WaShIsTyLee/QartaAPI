namespace QartaAPI.Entities.DTOs.RestaurantDTO
{
    public class CreateRestaurantDTO
    {

        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        public string? Logo { get; set; }
    }
}
