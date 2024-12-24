using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class SanctionTypeRepository : GenericRepository<SanctionType>, ISanctionTypeRepository
    {
        public SanctionTypeRepository(SanctionContext context) : base(context) { }
    }
}
