using AutoMapper;
using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using FONdrum.Domain.Shared.Results;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public ConfirmOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.FindByIdAndStatusAsync(request.Id, OrderStatus.PENDING, cancellationToken);
        if (order == null)
            return Error.NotFound(typeof(Order), request.Id.ToString());

        order.Confirm(_mapper.Map<OrderPaymentData>(request.OrderPayementData));

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
