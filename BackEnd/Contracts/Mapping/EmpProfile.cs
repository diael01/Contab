using AutoMapper;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //CreateMap<Employee, EmpDTO>();
            CreateMap<EmpDTO, Employee>()
                .ForMember(dest =>
               dest.EmpDeptNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpDeptNodeText)))
             .ForMember(dest =>
               dest.EmpActivityNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpActivityNodeText)))
             .ForMember(dest =>
               dest.EmpWorkTypeNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpWorkTypeNodeText)))
             .ForMember(dest =>
               dest.EmpFunctionNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpFunctionNodeText)));

            // Mapping when property names are different
            CreateMap<Employee, EmpDTO>()
              .ForMember(dest =>
               dest.EmpNodeAsText,
               opt => opt.MapFrom(src => src.EmpNode.ToString()))
              .ForMember(dest =>
                dest.ManagerNodeText,
                opt => opt.MapFrom(src => src.ManagerNode.ToString()))
              .ForMember(dest =>
                dest.EmpDeptNodeText,
                opt => opt.MapFrom(src => src.EmpDeptNode.ToString()))
              .ForMember(dest =>
                dest.EmpActivityNodeText,
                opt => opt.MapFrom(src => src.EmpActivityNode.ToString()))
              .ForMember(dest =>
                dest.EmpWorkTypeNodeText,
                opt => opt.MapFrom(src => src.EmpWorkTypeNode.ToString()))
            .ForMember(dest =>
               dest.EmpFunctionNodeText,
               opt => opt.MapFrom(src => src.EmpFunctionNode.ToString()));
        }

    }
}
