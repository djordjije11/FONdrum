namespace FONdrum.DTO.Models
{
    public record WineDto(byte[] RowVersion, Guid Id, string Name, double Price, int StockQuantity, string ImageUrl);
}
