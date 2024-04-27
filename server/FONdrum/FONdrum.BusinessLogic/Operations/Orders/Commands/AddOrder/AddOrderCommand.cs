using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.DTO.Models;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.AddOrder
{
    public sealed record AddOrderCommand(OrderDto Order) : ICommand<OrderIdDto>;
}
