using AutoMapper;
using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.BusinessLogic.Abstractions.Queries.Extensions;
using FONdrum.DataAccess;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetGrapeVarieties
{
    public class GetGrapeVarietiesQueryHandler : IQueryHandler<GetGrapeVarietiesQuery, GrapeVarietyCollectionDto>
    {
        private readonly FONdrumContext _context;
        private readonly IMapper _mapper;

        public GetGrapeVarietiesQueryHandler(FONdrumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GrapeVarietyCollectionDto>> Handle(GetGrapeVarietiesQuery request, CancellationToken cancellationToken)
        {
            long totalCount = await _context.GrapeVarieties.LongCountAsync();
            if (totalCount == 0)
                return new GrapeVarietyCollectionDto([], totalCount);

            //  WITH SUBQUERY
            ICollection<GrapeVarietyDto> grapeVarieties = await _mapper.ProjectTo<GrapeVarietyDto>(
                _context.GrapeVarieties
                .WhereIf(
                    gv =>
                    _context.Wines
                    .Where(w => request.WineStyleIds.Contains(w.StyleId))
                    .Select(w => w.VarietyId)
                    .Contains(gv.Id),
                    request.WineStyleIds.Any()
                    )
                .OrderBy(gv => gv.Id)
                ).ToListAsync(cancellationToken);

            return new GrapeVarietyCollectionDto(grapeVarieties, totalCount);

            //  WITH JOIN
            //return await _mapper.ProjectTo<GrapeVarietyDto>(
            //    _context.GrapeVarieties.If(
            //        request.WineStyleIds.Any(),
            //        query => query
            //        .Join(
            //            _context.Wines,
            //            gv => gv.Id,
            //            w => w.VarietyId,
            //            (gv, w) => new { GrapeVariety = gv, Wine = w }
            //            )
            //        .Where(joined => request.WineStyleIds.Contains(joined.Wine.StyleId))
            //        .Select(joined => joined.GrapeVariety)
            //        .Distinct()
            //        )
            //    ).ToListAsync(cancellationToken);
        }
    }
}
