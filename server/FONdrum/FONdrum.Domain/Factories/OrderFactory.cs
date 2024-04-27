using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using FONdrum.Domain.Shared.Results;

namespace FONdrum.Domain.Factories;

public class OrderFactory
{
    public static async Task<Result<Order>> CreateOrderAsync(
        ICollection<OrderItemData> orderItemsData,
        OrderBuyerData orderBuyerData,
        IWineRepository wineRepository,
        CancellationToken cancellationToken = default
        )
    {
        List<OrderItem> orderItems = new List<OrderItem>(orderItemsData.Count);

        foreach (var item in orderItemsData)
        {
            Result<OrderItem> result = await CreateOrderItemAsync(item, wineRepository, cancellationToken);
            if (result.IsError)
                return result.Error;

            orderItems.Add(result.Payload!);
        }

        return new Order(orderItems, OrderStatus.PENDING, orderBuyerData);
    }

    private async static Task<Result<OrderItem>> CreateOrderItemAsync(
            OrderItemData orderItemData,
            IWineRepository wineRepository,
            CancellationToken cancellationToken = default
            )
    {
        Wine? wine = await wineRepository.FindByIdAsync(orderItemData.WineId, cancellationToken);

        if (wine == null)
            return Error.NotFound(typeof(Wine), orderItemData.WineId.ToString());

        Result result = wine.DecreaseQuantity(orderItemData.Amount);
        if (result.IsError)
            return result.Error;

        return new OrderItem(wine, orderItemData.Amount);
    }
}
