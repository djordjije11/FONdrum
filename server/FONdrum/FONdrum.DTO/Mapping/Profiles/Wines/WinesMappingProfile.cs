using AutoMapper;
using FONdrum.Domain.Models;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Mapping.Profiles.Wines
{
    public class WinesMappingProfile : Profile
    {
        public WinesMappingProfile()
        {
            CreateMap<Wine, WineDto>();
            CreateMap<WineStyle, WineStyleDto>();
            CreateMap<GrapeVariety, GrapeVarietyDto>();
        }
    }
}
