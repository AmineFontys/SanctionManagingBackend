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
        private readonly IUnitOfWork _unitOfWork;

        public SanctionService(ISanctionRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SanctionDTO>> GetSanctionsByFlexworkerIdAsync(int flexworkerId)
        {
            var sanctions = await _repository.GetSanctionsByFlexworkerIdAsync(flexworkerId);
            return _mapper.Map<IEnumerable<SanctionDTO>>(sanctions);
        }

        public async Task CreateSanctionAsync(SanctionDTO sanctionDto)
        {

            var sanction = _mapper.Map<Sanction>(sanctionDto);

            await _repository.AddAsync(sanction);

            await _unitOfWork.SaveAsync();
        }

        public async Task<byte[]> GetSanctionPdfAsync(int sanctionId)
        {
            return await _repository.GetPdfByIdAsync(sanctionId);
        }

    }
}
