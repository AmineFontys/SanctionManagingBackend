using AutoMapper;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class FlexworkerService : GenericService<Flexworker, FlexworkerDTO>, IFlexworkerService
    {
        private readonly IFlexworkerRepository _repository;
        private readonly IMapper _mapper;

        public FlexworkerService(IFlexworkerRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<FlexworkerDTO>> GetByFullNameAsync(string fullName)
        {
            var flexworkers = await _repository.GetByFullNameAsync(fullName);

            return _mapper.Map<IEnumerable<FlexworkerDTO>>(flexworkers);
        }
    }

}
