using AutoMapper;
using RealEstateProperties.Core.DTOs;
using RealEstateProperties.Core.Entitites;

namespace RealEstateProperties.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
        }
    }
}
