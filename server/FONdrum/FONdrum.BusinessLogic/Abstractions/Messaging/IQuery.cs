using FONdrum.Domain.Shared.Results;
using MediatR;

namespace FONdrum.BusinessLogic.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
