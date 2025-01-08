namespace SanctionManagingBackend.DTO
{
    public class SanctionTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StandardLetterTemplate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
