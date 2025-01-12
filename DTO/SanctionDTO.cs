namespace SanctionManagingBackend.DTO
{
    public class SanctionDTO
    {
        public int Id { get; set; }
        public int FlexworkerId { get; set; }
        public int EmployeeId { get; set; }
        public string PdfFile { get; set; }
        public int SanctionTemplateId { get; set; }
        public string SanctionTemplateName { get; set; }
        public int Category { get; set; }
        public int Level { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Datum van aanmaak

    }
}
