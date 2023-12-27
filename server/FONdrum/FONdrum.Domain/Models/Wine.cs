namespace FONdrum.Domain.Models
{
    public class Wine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid StyleId { get; set; }
        public WineStyle Style { get; set; }
        public Guid VarietyId { get; set; }
        public GrapeVariety Variety { get; set; }
        public string ImageUrl { get; set; }
    }
}
