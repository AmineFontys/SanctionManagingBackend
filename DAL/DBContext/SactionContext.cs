using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Data.DBcontext
{
    public class SactionContext : DbContext
    {
        public SactionContext(DbContextOptions<SactionContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Flexworker> Flexworkers { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }
    }
}
