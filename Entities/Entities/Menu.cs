namespace QartaAPI.Entities.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
