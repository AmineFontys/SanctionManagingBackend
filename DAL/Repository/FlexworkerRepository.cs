using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class FlexworkerRepository : GenericRepository<Flexworker>, IFlexworkerRepository
    {
        public FlexworkerRepository(SanctionContext context) : base(context) { }

        public async Task<IEnumerable<Flexworker>> GetByFullNameAsync(string fullName)
        {
            return await _context.Set<Flexworker>()
                             .AsNoTracking()
                             .Where(f => string.Concat(f.FirstName, " ", f.LastName).ToLower() == fullName.ToLower())
                             .ToListAsync();
        }

    }
}
