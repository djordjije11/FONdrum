using FONdrum.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddOrder(OrderDto order)
        {
            return Ok();
        }
    }
}
