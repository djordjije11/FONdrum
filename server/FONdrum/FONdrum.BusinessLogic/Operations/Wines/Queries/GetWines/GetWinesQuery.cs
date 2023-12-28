using FONdrum.BusinessLogic.Abstractions.Messaging;
using FONdrum.DTO.Models;
using FONdrum.DTO.Request;

namespace FONdrum.BusinessLogic.Operations.Wines.Queries.GetWines
{
    public sealed record GetWinesQuery(
        PageParams PageParams, 
        ICollection<Guid> StyleIds, 
        ICollection<Guid> VarietyIds
        ) : IQuery<ICollection<WineDto>>;
}
