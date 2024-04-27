using FluentValidation;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Validation.Models.Orders;

public class OrderDtoValidator : AbstractValidator<OrderDto>
{
    public OrderDtoValidator(IValidator<OrderItemDto> orderItemDtoValidator)
    {
        RuleFor(o => o.Items)
            .NotEmpty()
            .WithMessage("Order must have at least one order item.");
        RuleForEach(o => o.Items)
            .SetValidator(orderItemDtoValidator);
        RuleFor(o => o.BuyerName)
            .NotEmpty()
            .WithMessage("Order buyer's name must not be empty.");
        RuleFor(o => o.BuyerPhoneNumber)
            .NotEmpty()
            .WithMessage("Order buyer's phone number must not be empty.");
        RuleFor(o => o.BuyerAddress)
            .NotEmpty()
            .WithMessage("Order buyer's address must not be empty.");
    }
}
