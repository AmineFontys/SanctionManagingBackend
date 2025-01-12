using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Interface
{
    public interface ISanctionRepository : IGenericRepository<Sanction>
    {
        Task<IEnumerable<Sanction>> GetSanctionsByFlexworkerIdAsync(int flexworkerId);
        Task<byte[]> GetPdfByIdAsync(int sanctionId);
        Task<bool> HasRecentWarningSanctionAsync(int flexworkerId, Category category, DateTime cutoffDate);
    }
}
