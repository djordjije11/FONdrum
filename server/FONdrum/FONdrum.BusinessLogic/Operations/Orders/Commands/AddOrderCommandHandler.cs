using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.DataAccess;
using FONdrum.Domain.Models;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
    {
        private FONdrumContext _context;

        public AddOrderCommandHandler(FONdrumContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderItem> orderItems = new List<OrderItem>(request.Order.Items.Count);
            
            foreach (OrderItemDto item in request.Order.Items)
            {
                Wine? wine = await _context.Wines
                    .FirstOrDefaultAsync(w => w.Id == item.WineId.Id, cancellationToken);

                Result result = ValidateOrderItemWine(item, wine);
                if (result.IsError) 
                    return result;

                wine!.StockQuantity -= item.Amount;
                orderItems.Add(new OrderItem(wine, item.Amount));
            }

            await _context.Orders.AddAsync(new Order(orderItems));
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        private static Result ValidateOrderItemWine(OrderItemDto item, Wine? wine)
        {
            if (wine == null)
            {
                return Error.NotFound(typeof(Wine), item.WineId.Id.ToString());
            }
            if (wine.RowVersion.SequenceEqual(item.WineId.RowVersion) == false)
            {
                return Error.Outdated();
            }
            if (wine.StockQuantity < item.Amount)
            {
                return Error.BadRequest("There is not enough amount in the stock.");
            }

            return Result.Success();
        }
    }
}
