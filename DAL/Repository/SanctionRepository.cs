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
                .AsNoTracking()
                .Where(s => s.FlexworkerId == flexworkerId)
                .ToListAsync();
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
