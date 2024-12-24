using AutoMapper;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class SanctionService : GenericService<Sanction, SanctionDTO>, ISanctionService
    {
        private readonly ISanctionRepository _repository;
        private readonly IMapper _mapper;

        public SanctionService(ISanctionRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
