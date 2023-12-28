using FluentValidation;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Validation.Models.Orders
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator(IValidator<OrderItemDto> orderItemDtoValidator)
        {
            RuleForEach(o => o.Items)
                .SetValidator(orderItemDtoValidator);
        }
    }
}
