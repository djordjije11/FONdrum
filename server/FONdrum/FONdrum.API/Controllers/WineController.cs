using FONdrum.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers
{
    [Route("api/wine")]
    [ApiController]
    public class WineController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<WineDto>> GetWines()
        {
            return Ok();
        }

        [HttpGet("/style")]
        public ActionResult<List<WineStyleDto>> GetWineStyles()
        {
            return Ok();
        }

        [HttpGet("/variety")]
        public ActionResult<List<GrapeVarietyDto>> GetGrapeVarieties()
        {
            return Ok();
        }
    }
}
