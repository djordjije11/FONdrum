namespace FONdrum.Domain.Models;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public Guid WineId { get; private set; }
    public Wine Wine { get; private set; }
    public int Amount { get; private set; }

    private OrderItem() { }

    public OrderItem(Wine wine, int amount)
    {
        Wine = wine;
        WineId = wine.Id;
        Amount = amount;
    }

    public void Cancel()
    {
        Wine.IncreaseQuantity(Amount);
    }
}
