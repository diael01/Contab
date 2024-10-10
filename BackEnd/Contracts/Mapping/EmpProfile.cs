using AutoMapper;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

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
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpDeptNodeAsText)))
             .ForMember(dest =>
               dest.EmpActivityNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpActivityNodeAsText)))
             .ForMember(dest =>
               dest.EmpWorkTypeNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpWorkTypeNodeAsText)))
             .ForMember(dest =>
               dest.EmpFunctionNode,
               opt => opt.MapFrom(src => HierarchyId.Parse(src.EmpFunctionNodeAsText)));

            // Mapping when property names are different
            CreateMap<Employee, EmpDTO>()
              .ForMember(dest =>
               dest.EmpNodeAsText,
               opt => opt.MapFrom(src => src.EmpNode.ToString()))
              .ForMember(dest =>
                dest.ManagerNodeAsText,
                opt => opt.MapFrom(src => src.ManagerNode.ToString()))
              .ForMember(dest =>
                dest.EmpDeptNodeAsText,
                opt => opt.MapFrom(src => src.EmpDeptNode.ToString()))
              .ForMember(dest =>
                dest.EmpActivityNodeAsText,
                opt => opt.MapFrom(src => src.EmpActivityNode.ToString()))
              .ForMember(dest =>
                dest.EmpWorkTypeNodeAsText,
                opt => opt.MapFrom(src => src.EmpWorkTypeNode.ToString()))
            .ForMember(dest =>
               dest.EmpFunctionNodeAsText,
               opt => opt.MapFrom(src => src.EmpFunctionNode.ToString()));
        }

    }
}
