using Microsoft.AspNetCore.Mvc;

namespace LearnManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("admin");
    }
}