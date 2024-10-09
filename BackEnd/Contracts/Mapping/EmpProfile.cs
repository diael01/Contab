using AutoMapper;
using Contracts.Models;
using Repository.Models;

namespace Contracts.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //CreateMap<Employee, EmpDTO>();
            CreateMap<EmpDTO, Employee>();

            // Mapping when property names are different
            CreateMap<Employee, EmpDTO>()
              .ForMember(dest =>
               dest.EmpNodeAsText,
               opt => opt.MapFrom(src => src.EmpNode.ToString()))
              .ForMember(dest =>
                dest.ManagerNodeAsText,
                opt => opt.MapFrom(src => src.ManagerNode.ToString()));
            //.ForMember(dest =>
            //   dest.EmpFunctionNodeAsText,
            //   opt => opt.MapFrom(src => src.EmpFunctionNode.ToString()));
        }

    }
}
