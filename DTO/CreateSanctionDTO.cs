namespace SanctionManagingBackend.DTO
{
    public class CreateSanctionDTO
    {
        public int FlexworkerId { get; set; }
        public int EmployeeId { get; set; }
        public int SanctionTemplateId { get; set; }
        public byte[] PdfFile { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
