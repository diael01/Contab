using AutoMapper;
using Contracts.Models;
using Repository.Models;


namespace Contracts.Mapping
{
    public class OrganisationProfile : Profile
    {
        public OrganisationProfile()
        {
            CreateMap<Organisation, OrgDTO>();
            CreateMap<OrgDTO, Organisation>();

            // Mapping when property names are different
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName));
        }
    }
}
