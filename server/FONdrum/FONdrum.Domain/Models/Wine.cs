using FONdrum.Domain.Shared.Results;

namespace FONdrum.Domain.Models
{
    public class Wine
    {
        public byte[] RowVersion { get; private set; }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Guid StyleId { get; private set; }
        public WineStyle Style { get; private set; }
        public Guid VarietyId { get; private set; }
        public GrapeVariety Variety { get; private set; }
        public string? ImageUrl { get; private set; }

        private Wine() { }

        public Wine(string name, decimal price, int stockQuantity, WineStyle style, GrapeVariety variety, string? imageUrl = null)
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

        public Result DecreaseQuantity(int amount)
        {
            if (StockQuantity < amount)
                return Error.BadRequest("There is not enough amount in the stock.");

            StockQuantity -= amount;

            return Result.Success();
        }

        public void IncreaseQuantity(int amount) 
        { 
            StockQuantity += amount;
        }
    }
}
