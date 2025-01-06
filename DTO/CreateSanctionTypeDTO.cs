namespace SanctionManagingBackend.DTO
{
    public class CreateSanctionTypeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile WordFile { get; set; }
    }
}
