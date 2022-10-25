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


        // Haku pelin nimellä
        [HttpGet]
        [Route("{haku}")]
        public ActionResult GetGamesByName(string haku)
        {
            // Hakutermi sisältyy pelin nimeen:
            var pelit = db.Pelits.Where(p => p.Nimi.ToLower().Contains(haku.ToLower()));

            // Täydellinen match olisi puolestaan:
            // var peli = db.Pelits.Where(p => p.Nimi == haku).FirstOrDefault();


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
