using FluentValidation;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Validation.Models.Orders
{
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(oi => oi.Amount)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The amount of wines in order item must be greater or equal to 1.");
        }
    }
}
