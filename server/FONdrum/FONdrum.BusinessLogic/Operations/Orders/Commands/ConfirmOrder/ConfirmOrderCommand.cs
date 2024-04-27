using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.DTO.Models;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.ConfirmOrder;

public sealed record ConfirmOrderCommand(Guid Id, OrderPayementDataDto OrderPayementData): ICommand;