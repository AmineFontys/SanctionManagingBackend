

using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Interface
{
    public interface IFlexworkerService : IGenericService<Flexworker, FlexworkerDTO>
    {
        Task<IEnumerable<FlexworkerDTO>> GetByFullNameAsync(string fullName);
    }
}
