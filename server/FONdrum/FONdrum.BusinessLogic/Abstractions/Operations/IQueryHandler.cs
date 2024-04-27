using FONdrum.Domain.Shared.Results;
using MediatR;

namespace FONdrum.BusinessLogic.Abstractions.Operations
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
