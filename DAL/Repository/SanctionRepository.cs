using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class SanctionRepository : GenericRepository<Sanction>, ISanctionRepository
    {
        public SanctionRepository(SanctionContext context) : base(context) { }
    }
}
