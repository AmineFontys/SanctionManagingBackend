using AutoMapper;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class SanctionTypeService : GenericService<SanctionType, SanctionTypeDTO>, ISanctionTypeService
    {
        private readonly ISanctionTypeRepository _repository;
        private readonly IMapper _mapper;

        public SanctionTypeService(ISanctionTypeRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
