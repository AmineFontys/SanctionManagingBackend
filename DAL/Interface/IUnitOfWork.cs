namespace SanctionManagingBackend.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        Task SaveAsync();
    }
}
