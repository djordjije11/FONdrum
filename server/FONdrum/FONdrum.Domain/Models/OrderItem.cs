namespace FONdrum.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid WineId { get; set; }
        public Wine Wine { get; set; }
        public int Amount { get; set; }

        public OrderItem() { }

        public OrderItem(Wine wine, int amount)
        {
            Wine = wine;
            WineId = wine.Id;
            Amount = amount;
        }
    }
}
