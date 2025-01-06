namespace SanctionManagingBackend.DTO
{
    public class SanctionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Vervang PdfBase64 door WordBase64
        public string WordBase64 { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
