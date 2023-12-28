using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.DTO.Models;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetWineStyles
{
    public sealed record GetWineStylesQuery(ICollection<Guid> GrapeVarietyIds) : IQuery<ICollection<WineStyleDto>>;
}
