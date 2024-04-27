using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using FONdrum.Domain.Shared.Results;
using System.Data;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public CancelOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.FindByIdAndStatusAsync(request.Id, OrderStatus.PENDING, cancellationToken);

        if (order == null)
            return Error.NotFound(typeof(Order), request.Id.ToString());

        order.Cancel();

        try
        {
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        catch (DBConcurrencyException)
        {
            return Error.Outdated();
        }

        return Result.Success();
    }
}
