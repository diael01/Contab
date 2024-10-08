using AutoMapper;
using Contracts.Models;
using Repository.Models;


namespace Contracts.Mapping
{
    public class OrganisationProfile : Profile
    {
        public OrganisationProfile()
        {
            //CreateMap<Organisation, OrgDTO>();
            CreateMap<OrgDTO, Organisation>();

            // Mapping when property names are different
            CreateMap<Organisation, OrgDTO>()
               .ForMember(dest =>
               dest.NodeAsText,
               opt => opt.MapFrom(src => src.Node.ToString()))
            .ForMember(dest =>
            dest.ParentNodeAsText,
            opt => opt.MapFrom(src => src.Name));
        }
    }
}
