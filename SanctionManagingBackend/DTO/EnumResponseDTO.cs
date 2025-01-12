using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DTO
{
    public class EnumResponseDTO
    {
        public List<EnumDTO<Level>> Levels { get; set; }
        public List<EnumDTO<Category>> Categories { get; set; }
    }
}
