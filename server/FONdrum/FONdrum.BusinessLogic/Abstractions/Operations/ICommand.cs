using FONdrum.Domain.Shared.Results;
using MediatR;

namespace FONdrum.BusinessLogic.Abstractions.Operations
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
