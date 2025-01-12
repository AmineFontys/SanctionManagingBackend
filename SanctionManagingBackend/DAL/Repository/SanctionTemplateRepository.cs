using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class SanctionTemplateRepository : GenericRepository<SanctionTemplate>, ISanctionTemplateRepository
    {
        public SanctionTemplateRepository(SanctionContext context) : base(context) { }
    }
}
