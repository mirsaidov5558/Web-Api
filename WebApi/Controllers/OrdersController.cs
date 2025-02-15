using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get(int id)
        {
            return Ok(new { id });
        }
    }
}
