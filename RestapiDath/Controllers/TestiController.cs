using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestapiDath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestiController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetMessage()
        {
            return Ok("Hyvää viikkoa");
        }

    }
}
