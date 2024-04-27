namespace FONdrum.DTO.Models
{
    public record WineDto(
        byte[] RowVersion, 
        Guid Id, 
        string Name, 
        decimal Price, 
        int StockQuantity, 
        string? ImageUrl, 
        string WineStyle,
        string GrapeVariety
        );
}
