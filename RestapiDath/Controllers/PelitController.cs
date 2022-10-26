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


        // Pelin haku genre id:n mukaan
        [HttpGet]
        [Route("genreid/{genreId}")]
        public ActionResult GetByCategoryId(int genreId)
        {
            if (genreId > 0)
            {
                var pelit = db.Pelits.Where(p => p.GenreId == genreId).ToList();
                return Ok(pelit);
            }

            return BadRequest("Genre id pitää olla kokonaisluku");
        }


        // Haku pelin nimellä
        [HttpGet]
        [Route("{haku}")]
        public ActionResult GetGamesByName(string haku)
        {
            // Hakutermi sisältyy pelin nimeen:
            var pelit = db.Pelits.Where(p => p.Nimi.ToLower().Contains(haku.ToLower()));

            // Täydellinen match olisi puolestaan:
            // var peli = db.Pelits.Where(p => p.Nimi.ToLower() == haku.ToLower()).FirstOrDefault();


            return Ok(pelit);
        }


        // Uuden pelin lisääminen
        [HttpPost]
        public ActionResult AddNew([FromBody] Pelit p)
        {
          
                try
                {
                    db.Pelits.Add(p);
                    db.SaveChanges();
                    return Ok("Lisättiin uusi peli: " + p.Nimi);
                }
                catch (Exception e)
                {
                    return BadRequest("Virhe. Lue lisää tästä: " + e.Message);
                }
            
        }

    }
}
