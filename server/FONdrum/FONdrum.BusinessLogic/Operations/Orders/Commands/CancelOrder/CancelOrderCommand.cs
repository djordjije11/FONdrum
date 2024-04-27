using FONdrum.BusinessLogic.Abstractions.Operations;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(Guid Id) : ICommand;

