using FONdrum.API.Controllers.Abstractions;
using FONdrum.API.Filters;
using FONdrum.BusinessLogic.Operations.Orders.Commands.AddOrder;
using FONdrum.BusinessLogic.Operations.Orders.Commands.CancelOrder;
using FONdrum.BusinessLogic.Operations.Orders.Commands.ConfirmOrder;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : AbstractController
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [Valid]
    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] OrderDto order, CancellationToken cancellationToken)
    {
        Result<OrderIdDto> result = await _sender.Send(new AddOrderCommand(order), cancellationToken);
        return result.IsError ? HandleError(result.Error) : Ok(result.Payload);
    }

    [HttpPatch("{orderId:guid}/cancel")]
    public async Task<ActionResult> CancelOrder([FromRoute] Guid orderId, CancellationToken cancellationToken)
    {
        Result result = await _sender.Send(new CancelOrderCommand(orderId), cancellationToken);
        return result.IsError ? HandleError(result.Error) : NoContent();
    }

    [Valid]
    [HttpPatch("{orderId:guid}/confirm")]
    public async Task<ActionResult> ConfirmOrder([FromRoute] Guid orderId, [FromBody] OrderPayementDataDto orderPayementDataDto, CancellationToken cancellationToken)
    {
        Result result = await _sender.Send(new ConfirmOrderCommand(orderId, orderPayementDataDto), cancellationToken);
        return result.IsError ? HandleError(result.Error) : NoContent();
    }
}
