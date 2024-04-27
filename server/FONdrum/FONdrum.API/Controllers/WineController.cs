using FONdrum.API.Controllers.Abstractions;
using FONdrum.API.Filters;
using FONdrum.BusinessLogic.Operations.Wines.Queries.GetGrapeVarieties;
using FONdrum.BusinessLogic.Operations.Wines.Queries.GetWines;
using FONdrum.BusinessLogic.Operations.Wines.Queries.GetWineStyles;
using FONdrum.Domain.Shared.Paginations;
using FONdrum.DTO.Models;
using FONdrum.DTO.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers
{
    [Route("api/wine")]
    [ApiController]
    public class WineController : AbstractController
    {
        private readonly ISender _sender;

        public WineController(ISender sender)
        {
            _sender = sender;
        }

        [Valid]
        [HttpGet]
        public async Task<ActionResult<List<WineDto>>> GetWines(
            [FromQuery] PageParams pageParams, 
            [FromQuery(Name = "styleId")] List<Guid> styleIds, 
            [FromQuery(Name = "varietyId")] List<Guid> varietyIds,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetWinesQuery(pageParams, styleIds, varietyIds), cancellationToken);
            Paged<WineDto> pagedWines = result.Payload!;
            AddPaginationHeaders(pagedWines.PageInfo);
            return Ok(pagedWines.Data);
        }

        [HttpGet("style")]
        public async Task<ActionResult<WineStyleCollectionDto>> GetWineStyles(
            [FromQuery(Name = "varietyId")] List<Guid> varietyIds, 
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetWineStylesQuery(varietyIds), cancellationToken);
            return Ok(result.Payload);
        }

        [HttpGet("variety")]
        public async Task<ActionResult<GrapeVarietyCollectionDto>> GetGrapeVarieties(
            [FromQuery(Name = "styleId")] List<Guid> styleIds, 
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetGrapeVarietiesQuery(styleIds), cancellationToken);
            return Ok(result.Payload);
        }
    }
}
