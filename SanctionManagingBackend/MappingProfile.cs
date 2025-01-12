using AutoMapper;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flexworker, FlexworkerDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            // Enkelvoudige mapping van Sanction naar SanctionDTO
            CreateMap<Sanction, SanctionDTO>()
                .ForMember(dest => dest.SanctionTemplateName, opt => opt.MapFrom(src => src.SanctionTemplate.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (int)src.SanctionTemplate.Category))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => (int)src.SanctionTemplate.Level))
                .ForMember(dest => dest.PdfFile, opt => opt.MapFrom(src => Convert.ToBase64String(src.PdfFile)))
                .ReverseMap()
                .ForMember(dest => dest.PdfFile, opt => opt.MapFrom(src => Convert.FromBase64String(src.PdfFile)));

            CreateMap<SanctionTemplate, SanctionTemplateDTO>().ReverseMap();

            // Mapping van CreateSanctionDTO naar Sanction
            CreateMap<CreateSanctionDTO, Sanction>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
