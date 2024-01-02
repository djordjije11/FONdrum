using FluentValidation;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Validation.Models.Orders
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator(IValidator<OrderItemDto> orderItemDtoValidator)
        {
            RuleFor(o => o.Items)
                .NotEmpty()
                .WithMessage("Order must have at least one order item.");
            RuleForEach(o => o.Items)
                .SetValidator(orderItemDtoValidator);
        }
    }
}
