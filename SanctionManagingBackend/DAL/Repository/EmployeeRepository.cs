using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SanctionContext context) : base(context) { }
    }
}
