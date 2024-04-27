using FluentValidation;
using FONdrum.DTO.Request;

namespace FONdrum.DTO.Validation.Request
{
    public class PageParamsValidator : AbstractValidator<PageParams>
    {
        public PageParamsValidator()
        {
            RuleFor(pp => pp.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page size must be greater than or equal to 1.");
            RuleFor(pp => pp.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be greater than or equal to 1.");
        }
    }
}
