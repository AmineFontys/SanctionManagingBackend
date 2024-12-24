using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Interface
{
    public interface ISanctionService : IGenericService<Sanction, SanctionDTO>
    {
    }
}
