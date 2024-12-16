using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Data.Dal
{
    public class SactionContext : DbContext
    {
        public SactionContext(DbContextOptions<SactionContext> options) : base(options)
        {
        }

        public DbSet<EmployeeDto> Employees { get; set; }
    }
}
