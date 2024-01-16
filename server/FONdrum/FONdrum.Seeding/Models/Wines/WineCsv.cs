namespace FONdrum.Seeding.Models.Wines;

public class WineCsv
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Style { get; set; }
    public string Variety { get; set; }
    public string? ImageUrl { get; set; }
}