using AutoMapper;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class EmployeeService : GenericService<Employee, EmployeeDTO>, IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
