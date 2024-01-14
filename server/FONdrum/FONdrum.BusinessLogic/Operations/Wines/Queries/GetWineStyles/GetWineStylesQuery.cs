using FONdrum.BusinessLogic.Abstractions.Operations;
using FONdrum.DTO.Models;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetWineStyles
{
    public sealed record GetWineStylesQuery(ICollection<Guid> GrapeVarietyIds) : IQuery<WineStyleCollectionDto>;
}
