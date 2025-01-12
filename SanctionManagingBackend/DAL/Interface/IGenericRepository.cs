using System.Linq.Expressions;

namespace SanctionManagingBackend.DAL.Interface
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetByIdAsync(int id, string includeProperties = "");
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(int id);
        Task SaveAsync();
    }
}
