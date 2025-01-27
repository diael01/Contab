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
               opt => opt.MapFrom(src => (string.IsNullOrEmpty(src.EmpDeptNodeText) && !string.IsNullOrWhiteSpace(src.EmpDeptNodeText))
               ? HierarchyId.Parse(src.EmpDeptNodeText)
               : null))
             .ForMember(dest =>
               dest.EmpActivityNode,
               opt => opt.MapFrom(src => (string.IsNullOrEmpty(src.EmpActivityNodeText) && !string.IsNullOrWhiteSpace(src.EmpActivityNodeText))
                                ? HierarchyId.Parse(src.EmpActivityNodeText)
                                : null))
             .ForMember(dest =>
               dest.EmpWorkTypeNode,
               opt => opt.MapFrom(src => (string.IsNullOrEmpty(src.EmpWorkTypeNodeText) && !string.IsNullOrWhiteSpace(src.EmpWorkTypeNodeText))
                  ? HierarchyId.Parse(src.EmpWorkTypeNodeText)
                  : null))
             .ForMember(dest =>
               dest.EmpFunctionNode,
               opt => opt.MapFrom(src => (string.IsNullOrEmpty(src.EmpFunctionNodeText) && !string.IsNullOrWhiteSpace(src.EmpFunctionNodeText))
               ? HierarchyId.Parse(src.EmpFunctionNodeText)
               : null));

            // Mapping when property names are different
            CreateMap<Employee, EmpDTO>()
              .ForMember(dest =>
               dest.EmpNodeText,
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
