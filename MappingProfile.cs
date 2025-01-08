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
            CreateMap<Sanction, SanctionDTO>()
            .ForMember(dest => dest.PdfFile, opt => opt.MapFrom(src => Convert.ToBase64String(src.PdfFile))) // Byte[] naar Base64 string
            .ReverseMap()
            .ForMember(dest => dest.PdfFile, opt => opt.MapFrom(src => Convert.FromBase64String(src.PdfFile))); // Base64 string naar Byte[]
            CreateMap<SanctionType, SanctionTypeDTO>().ReverseMap();
        }
    }
}
