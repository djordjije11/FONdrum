using AutoMapper;
using FONdrum.Domain.Models;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Mapping.Profiles.Orders
{
    public class OrdersMappingProfile : Profile
    {
        public OrdersMappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderPayementDataDto, OrderPaymentData>();
        }
    }
}
