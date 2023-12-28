namespace FONdrum.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime Date { get; set; }

        public Order() { }

        public Order(ICollection<OrderItem> items)
        {
            Items = items;
        }
    }
}
