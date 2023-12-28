using FONdrum.BusinessLogic.Operations.Wines.Queries.GetGrapeVarieties;
using FONdrum.DTO.Models;
using FONdrum.DTO.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers
{
    [Route("api/wine")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly ISender _sender;

        public WineController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public ActionResult<List<WineDto>> GetWines(
            [FromQuery] PageParams pageParams, 
            [FromQuery(Name = "styleId")] List<Guid> styleIds, 
            [FromQuery(Name = "varietyId")] List<Guid> varietyIds,
            CancellationToken cancellationToken
            )
        {
            Console.WriteLine(pageParams.PageNumber);
            Console.WriteLine(pageParams.PageSize);
            Console.WriteLine(styleIds.Count);
            Console.WriteLine(varietyIds.FirstOrDefault());
            return Ok();
        }

        [HttpGet("style")]
        public ActionResult<List<WineStyleDto>> GetWineStyles(
            [FromQuery(Name = "varietyId")] List<Guid> varietyIds, 
            CancellationToken cancellationToken
            )
        {
            return Ok();
        }

        [HttpGet("variety")]
        public async Task<ActionResult<List<GrapeVarietyDto>>> GetGrapeVarieties(
            [FromQuery(Name = "styleId")] List<Guid> styleIds, 
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetGrapeVarietiesQuery(styleIds), cancellationToken);
            return Ok(result.Payload);
        }
    }
}
