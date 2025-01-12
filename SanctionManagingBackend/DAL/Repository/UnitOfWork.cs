using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.DBcontext;

namespace SanctionManagingBackend.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SanctionContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(SanctionContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                // Maak de repository en sla deze op in de dictionary
                _repositories[typeof(T)] = new GenericRepository<T>(_context);
            }

            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

