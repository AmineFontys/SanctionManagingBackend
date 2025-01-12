using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class SanctionRepository : GenericRepository<Sanction>, ISanctionRepository
    {
        public SanctionRepository(SanctionContext context) : base(context) { }

        public async Task<IEnumerable<Sanction>> GetSanctionsByFlexworkerIdAsync(int flexworkerId)
        {
            return await _context.Set<Sanction>()
                .Include(s => s.SanctionTemplate) // Inclusief de gerelateerde SanctionTemplate
                .AsNoTracking()
                .Where(s => s.FlexworkerId == flexworkerId)
                .ToListAsync();
        }
        public async Task<bool> HasRecentWarningSanctionAsync(int flexworkerId, Category category, DateTime cutoffDate)
        {
            return await _context.Set<Sanction>()
                .AnyAsync(s => s.FlexworkerId == flexworkerId
                            && s.SanctionTemplate.Category == category
                            && s.SanctionTemplate.Level == Level.Warning
                            && s.CreatedAt >= cutoffDate);
        }
        public async Task<byte[]> GetPdfByIdAsync(int sanctionId)
        {
            var sanction = await _context.Set<Sanction>()
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == sanctionId);

            return sanction.PdfFile;
        }
    }
}
