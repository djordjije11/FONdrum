using FluentValidation;
using FONdrum.DTO.Models;

namespace FONdrum.DTO.Validation.Models.Orders;

public class OrderPayementDataDtoValidator : AbstractValidator<OrderPayementDataDto>
{
    public OrderPayementDataDtoValidator()
    {
        RuleFor(o => o.OrderID)
            .NotEmpty()
            .WithMessage("OrderID must not be empty.");
        RuleFor(o => o.PayerEmailAddress)
            .EmailAddress()
            .WithMessage("PayerEmailAddress must be valid email address.");
    }
}
