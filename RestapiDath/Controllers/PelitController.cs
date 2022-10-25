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

        // Kaikkien pelien haku
        [HttpGet]
        public ActionResult GetAll()
        {
            var pelit = db.Pelits.ToList();
            return Ok(pelit);
        }

        // Uuden pelin lisääminen
        [HttpPost]
        public ActionResult AddNew([FromBody] Pelit p)
        {
            db.Pelits.Add(p);
            db.SaveChanges();
            return Ok("Lisättiin uusi peli: " + p.Nimi);
        }

    }
}
