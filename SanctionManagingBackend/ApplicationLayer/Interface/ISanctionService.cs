using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Interface
{
    public interface ISanctionService : IGenericService<Sanction, SanctionDTO>
    {
        Task<IEnumerable<SanctionDTO>> GetSanctionsByFlexworkerIdAsync(int flexworkerId);
        Task<byte[]> GetSanctionPdfAsync(int sanctionId);
        Task<OperationResult> CreateSanctionAsync(CreateSanctionDTO dto);
    }
}
