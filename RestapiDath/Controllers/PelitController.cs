using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestapiDath.Models;

namespace RestapiDath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelitController : ControllerBase
    {
        // Tietokantakonteksti
        PeliDBContext db = new PeliDBContext();

        [HttpGet]
        public ActionResult GetAll()
        {
            var pelit = db.Pelits.ToList();
            return Ok(pelit);
        }

    }
}
