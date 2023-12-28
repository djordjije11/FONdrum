using FONdrum.Domain.Shared.Results;
using MediatR;

namespace FONdrum.BusinessLogic.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
