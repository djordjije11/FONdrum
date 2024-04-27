using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.Domain.Factories;
using FONdrum.Domain.Models;
using FONdrum.Domain.Repositories;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using System.Data;

namespace FONdrum.BusinessLogic.Operations.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand, OrderIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IWineRepository _wineRepository;

        public AddOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IWineRepository wineRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _wineRepository = wineRepository;
        }

        /// <summary>
        /// Returns Error Result if any OrderItem's Wine is not found, or RowVersion is not valid, or StockQuantity is less than Amount. Otherwise returns Result without Payload.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Error Result - if any OrderItem's Wine is not found, or RowVersion is not valid, or StockQuantity is less than Amount;  Result without Payload - otherwise.</returns>
        public async Task<Result<OrderIdDto>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            ICollection<OrderItemData> orderItemsData = request.Order.Items
                .Select(item => new OrderItemData(item.WineId.Id, item.WineId.RowVersion, item.Amount))
                .ToList();

            Result<Order> result = await OrderFactory.CreateOrderAsync(
                orderItemsData, 
                new OrderBuyerData(request.Order.BuyerName, request.Order.BuyerPhoneNumber, request.Order.BuyerAddress), 
                _wineRepository, 
                cancellationToken
                );
            if (result.IsError)
                return result.Error;

            await _orderRepository.AddAsync(result.Payload!, cancellationToken);

            try
            {
                await _unitOfWork.SaveAsync(cancellationToken);
            }
            catch (DBConcurrencyException)
            {
                return Error.Outdated();
            }

            return new OrderIdDto(result.Payload!.Id);
        }
    }
}
