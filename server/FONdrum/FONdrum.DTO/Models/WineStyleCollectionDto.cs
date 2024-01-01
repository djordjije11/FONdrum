namespace FONdrum.DTO.Models
{
    public record WineStyleCollectionDto(ICollection<WineStyleDto> WineStyles, long TotalCount);
}
