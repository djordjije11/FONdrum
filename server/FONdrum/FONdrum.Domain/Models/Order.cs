using FONdrum.Domain.Exceptions;

namespace FONdrum.Domain.Models;

public class Order
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public ICollection<OrderItem> Items { get; init; } = new List<OrderItem>();
    public OrderStatus Status { get; private set; }
    public OrderBuyerData BuyerData { get; private set; }
    public OrderPaymentData PaymentData { get; private set; }

    private Order() { }

    public Order(ICollection<OrderItem> items, OrderStatus status, OrderBuyerData buyerData)
    {
        Items = items;
        Status = status;
        BuyerData = buyerData;
        PaymentData = OrderPaymentData.Empty();
    }

    public void Cancel()
    {
        if (Status != OrderStatus.PENDING)
            throw new OrderIllegalStatusActionException("Order cannot be canceled if status is not PENDING.");

        foreach (OrderItem item in Items)
        {
            item.Cancel();
        }

        Status = OrderStatus.CANCELED;
    }

    public void Confirm(OrderPaymentData paymentData)
    {
        PaymentData = paymentData;
        Status = OrderStatus.CONFIRMED;
    }
}
