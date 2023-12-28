using FONdrum.API.Controllers.Abstractions;
using FONdrum.API.Filters;
using FONdrum.BusinessLogic.Operations.Orders.Commands;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers
{
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
        public async Task<ActionResult> AddOrder(OrderDto order)
        {
            Result result = await _sender.Send(new AddOrderCommand(order));
            return result.IsError ? HandleError(result.Error) : NoContent();
        }
    }
}
