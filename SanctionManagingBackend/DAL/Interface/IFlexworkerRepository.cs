using SanctionManagingBackend.Data.Entity;

namespace SanctionManagingBackend.DAL.Interface
{
    public interface IFlexworkerRepository: IGenericRepository<Flexworker>
    {
        Task<IEnumerable<Flexworker>> GetByFullNameAsync(string fullName);

    }
}
