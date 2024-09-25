using AutoMapper;   
using Contracts.Models;
using Repository.Models;

namespace Contracts.Mapping
{
    public class EmpProfile : Profile
    {
            public EmpProfile()
            {
                CreateMap<Employee, EmpDTO>();
                CreateMap<EmpDTO, Employee>();

                // Mapping when property names are different
                CreateMap<Employee, EmpDTO>()
                  .ForMember(dest =>
                   dest.EmpNodeText,
                   opt => opt.MapFrom(src => src.EmpNode.ToString()))
                  .ForMember(dest =>
                    dest.ManagerNodeText,
                    opt => opt.MapFrom(src => src.ManagerNode))
                 .ForMember(dest =>
                    dest.FunctionNodeText,
                    opt => opt.MapFrom(src => src.EmpFunctionNode));
        }
        
    }
}
