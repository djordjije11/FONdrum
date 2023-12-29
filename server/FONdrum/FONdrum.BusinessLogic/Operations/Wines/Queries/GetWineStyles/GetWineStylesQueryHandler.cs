using AutoMapper;
using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.BusinessLogic.Abstractions.Queries.Extensions;
using FONdrum.DataAccess;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetWineStyles
{
    public class GetWineStylesQueryHandler : IQueryHandler<GetWineStylesQuery, ICollection<WineStyleDto>>
    {
        private FONdrumContext _context;
        private IMapper _mapper;

        public GetWineStylesQueryHandler(FONdrumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ICollection<WineStyleDto>>> Handle(GetWineStylesQuery request, CancellationToken cancellationToken)
        {
            //  WITH SUBQUERY
            return await _mapper.ProjectTo<WineStyleDto>(
                _context.WineStyles.WhereIf(
                    ws =>
                    _context.Wines
                    .Where(w => request.GrapeVarietyIds.Contains(w.VarietyId))
                    .Select(w => w.StyleId)
                    .Contains(ws.Id),
                    request.GrapeVarietyIds.Any()
                    )
                ).ToListAsync(cancellationToken);

            //  WITH JOIN
            //return await _mapper.ProjectTo<WineStyleDto>(
            //    _context.WineStyles.If(
            //        request.GrapeVarietyIds.Any(),
            //        query => query
            //        .Join(
            //            _context.Wines,
            //            ws => ws.Id,
            //            w => w.WineStyleId,
            //            (ws, w) => new { WineStyle = ws, Wine = w }
            //            )
            //        .Where(joined => request.GrapeVarietyIds.Contains(joined.Wine.VarietyId))
            //        .Select(joined => joined.WineStyle)
            //        .Distinct()
            //        )
            //    ).ToListAsync(cancellationToken);
        }
    }
}
