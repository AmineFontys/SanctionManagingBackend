using AutoMapper;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class SanctionService : GenericService<Sanction, SanctionDTO>, ISanctionService
    {
        private readonly ISanctionRepository _sanctionRepository;
        private readonly ISanctionTemplateRepository _sanctionTemplateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SanctionService(
            ISanctionRepository sanctionRepository,
            ISanctionTemplateRepository sanctionTemplateRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        ) : base(sanctionRepository, mapper, unitOfWork)
        {
            _sanctionRepository = sanctionRepository;
            _sanctionTemplateRepository = sanctionTemplateRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SanctionDTO>> GetSanctionsByFlexworkerIdAsync(int flexworkerId)
        {
            var sanctions = await _sanctionRepository.GetSanctionsByFlexworkerIdAsync(flexworkerId);
            var sanctionDTOs = _mapper.Map<IEnumerable<SanctionDTO>>(sanctions);
            return sanctionDTOs;
        }

        public async Task<OperationResult> CreateSanctionAsync(CreateSanctionDTO dto)
        {
            if (dto == null)
            {
                return OperationResult.Fail("Sanctie gegevens zijn vereist.");
            }

            var template = await _sanctionTemplateRepository.GetByIdAsync(dto.SanctionTemplateId);
            if (template == null)
            {
                return OperationResult.Fail("Geselecteerde sanctietype bestaat niet.");
            }

            if (template.Level == Level.Suspension)
            {
                var cutoffDate = DateTime.UtcNow.AddMonths(-6);
                bool hasWarning = await _sanctionRepository.HasRecentWarningSanctionAsync(
                    dto.FlexworkerId,
                    template.Category,
                    cutoffDate
                );

                if (!hasWarning)
                {
                    return OperationResult.Fail("De flexkracht heeft nog geen recente waarschuwing binnen dezelfde categorie ontvangen.");
                }
            }

            var sanction = _mapper.Map<Sanction>(dto);
            sanction.CreatedAt = DateTime.UtcNow;

            await _sanctionRepository.AddAsync(sanction);
            await _unitOfWork.SaveAsync();

            return OperationResult.Ok();
        }

        public async Task<byte[]> GetSanctionPdfAsync(int sanctionId)
        {
            var pdf = await _sanctionRepository.GetPdfByIdAsync(sanctionId);
            if (pdf == null)
            {
                throw new KeyNotFoundException("PDF voor de opgegeven sanctie is niet gevonden.");
            }
            return pdf;
        }
    }
}
