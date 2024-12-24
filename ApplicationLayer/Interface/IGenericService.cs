using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Interface
{
    public interface IGenericService<TEntity, TDto> where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(TDto dto);
    }
}
