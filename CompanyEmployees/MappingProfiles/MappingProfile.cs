using AutoMapper;
using Entities.Models;
using static Shared.DataTransferObjects;

namespace CompanyEmployees.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // compnay
            CreateMap<Company, CompanyDto>().ForMember(
                c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<CompanyForUpdateDto, Company>();
            // employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        }
    }
}
