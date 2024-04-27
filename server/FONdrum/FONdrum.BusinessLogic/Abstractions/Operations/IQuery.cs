using FONdrum.Domain.Shared.Results;
using MediatR;

namespace FONdrum.BusinessLogic.Abstractions.Operations
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
