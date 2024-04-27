using AutoMapper;
using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.BusinessLogic.Abstractions.Queries.Extensions;
using FONdrum.DataAccess;
using FONdrum.Domain.Shared.Paginations;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetWines
{
    public class GetWinesQueryHandler : IQueryHandler<GetWinesQuery, Paged<WineDto>>
    {
        private readonly FONdrumContext _context;
        private readonly IMapper _mapper;

        public GetWinesQueryHandler(FONdrumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Paged<WineDto>>> Handle(GetWinesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Wines
                .Where(w => w.StockQuantity > 0)
                .WhereIf(
                    w => request.StyleIds.Contains(w.StyleId),
                    request.StyleIds.Any()
                    )
                .WhereIf(
                    w => request.VarietyIds.Contains(w.VarietyId),
                    request.VarietyIds.Any()
                    );

            long winesCount = await query.LongCountAsync(cancellationToken);
            if (winesCount == 0)
                return Paged<WineDto>.Empty();

            IList<WineDto> wines = await _mapper.ProjectTo<WineDto>(query.Page(request.PageParams)).ToListAsync();
            var pageInfo = new PageInfo(winesCount, request.PageParams.PageSize, request.PageParams.PageNumber);

            return Paged<WineDto>.Of(wines, pageInfo);
        }
    }
}
