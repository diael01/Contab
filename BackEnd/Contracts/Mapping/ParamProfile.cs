using AutoMapper;
using Contracts.Models;

namespace Contracts.Mapping
{
    public class ParamProfile : Profile
    {
        public ParamProfile()
        {
            CreateMap<ParamDTO, Param>();

            // Mapping when property names are different
            CreateMap<Param, ParamDTO>()
            .ForMember(dest =>
            dest.EcnDirectorText,
            opt => opt.MapFrom(src => src.EcnDirector.ToString()))
            .ForMember(dest =>
            dest.GenDirectorText,
            opt => opt.MapFrom(src => src.GenDirector.ToString()))
            .ForMember(dest =>
            dest.FinDirectorText,
            opt => opt.MapFrom(src => src.FinDirector.ToString()));
           
        }
    }
}

   
