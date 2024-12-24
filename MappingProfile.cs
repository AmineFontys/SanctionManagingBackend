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
        }
    }
}
