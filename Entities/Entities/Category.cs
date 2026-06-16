namespace QartaAPI.Entities.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Order { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; } = null!;


    }
}
