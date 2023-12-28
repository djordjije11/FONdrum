using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.DTO.Models;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetGrapeVarieties
{
    public sealed record GetGrapeVarietiesQuery(ICollection<Guid> WineStyleIds) : IQuery<ICollection<GrapeVarietyDto>>;
}
