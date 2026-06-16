namespace QartaAPI.Entities.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } 

        public decimal Price { get; set; }

        public string? Image { get; set; } = string.Empty;

        public bool IsEnabled { get; set; } = true;

        public int Order { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

    }
}
