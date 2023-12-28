using AutoMapper;
using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.BusinessLogic.Abstractions.Queries.Extensions;
using FONdrum.DataAccess;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetGrapeVarieties
{
    public class GetGrapeVarietiesQueryHandler : IQueryHandler<GetGrapeVarietiesQuery, ICollection<GrapeVarietyDto>>
    {
        private readonly FONdrumContext _context;
        private readonly IMapper _mapper;

        public GetGrapeVarietiesQueryHandler(FONdrumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ICollection<GrapeVarietyDto>>> Handle(GetGrapeVarietiesQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<GrapeVarietyDto>(
                _context.GrapeVarieties.WhereIf(
                    gv => 
                    _context.Wines
                    .Where(w => request.WineStyleIds.Contains(w.StyleId))
                    .Select(w => w.VarietyId)
                    .Contains(gv.Id), 
                    request.WineStyleIds.Any())
                ).ToListAsync();
        }
    }
}
