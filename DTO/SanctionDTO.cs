namespace SanctionManagingBackend.DTO
{
    public class SanctionDTO
    {
        public int Id { get; set; }
        public int FlexworkerId { get; set; }
        public int EmployeeId { get; set; }
        public string PdfFile { get; set; }
        public string SanctionType { get; set; } // Type sanctie
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Datum van aanmaak

    }
}
