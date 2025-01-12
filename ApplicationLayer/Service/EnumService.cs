using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class EnumService : IEnumService
    {
        public EnumResponseDTO GetEnums()
        {
            return new EnumResponseDTO
            {
                Levels = Enum.GetValues(typeof(Level))
                .Cast<Level>()
                             .Select(e => new EnumDTO<Level> { Value = (int)e, Name = e.ToString() })
                             .ToList(),
                Categories = Enum.GetValues(typeof(Category))
                .Cast<Category>()
                                .Select(e => new EnumDTO<Category> { Value = (int)e, Name = e.ToString() })
                                .ToList()
            };
        }
    }
}
