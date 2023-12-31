using AutoMapper;
using FONdrum.Domain.Models;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Mapping.Profiles.Wines
{
    public class WinesMappingProfile : Profile
    {
        public WinesMappingProfile()
        {
            CreateMap<Wine, WineDto>()
                .ConstructUsing((w) => new WineDto(
                    w.RowVersion, w.Id, w.Name, w.Price, w.StockQuantity, w.ImageUrl, w.Style.Name, w.Variety.Name)
                );
            CreateMap<WineStyle, WineStyleDto>();
            CreateMap<GrapeVariety, GrapeVarietyDto>();
        }
    }
}
