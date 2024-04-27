namespace FONdrum.DTO.Models
{
    public record GrapeVarietyCollectionDto(ICollection<GrapeVarietyDto> GrapeVarieties, long TotalCount);
}
