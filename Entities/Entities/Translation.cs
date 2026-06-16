namespace QartaAPI.Entities.Entities
{
    public class Translation
    {
        public int Id { get; set; }

        public string EntityType { get; set; } = string.Empty;

        public int EntityId { get; set; }

        public string Language { get; set; } = string.Empty;

        public string Field { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}