using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Interface
{
    public interface IEmployeeService : IGenericService<Employee, EmployeeDTO>
    {
    }
}
