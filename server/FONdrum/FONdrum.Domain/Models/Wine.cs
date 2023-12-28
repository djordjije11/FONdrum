namespace FONdrum.Domain.Models
{
    public class Wine
    {
        public byte[] RowVersion { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid StyleId { get; set; }
        public WineStyle Style { get; set; }
        public Guid VarietyId { get; set; }
        public GrapeVariety Variety { get; set; }
        public string? ImageUrl { get; set; }

        public Wine() { }

        public Wine(string name, double price, int stockQuantity, WineStyle style, GrapeVariety variety, string? imageUrl = null)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Style = style;
            StyleId = style.Id;
            Variety = variety;
            VarietyId = variety.Id;
            ImageUrl = imageUrl;
        }
    }
}
