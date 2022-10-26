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

        // Pelin poistaminen
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Remove(int id)
        {
            var poistettavaPeli = db.Pelits.Find(id);
            if (poistettavaPeli != null)
                {

                    try
                    {
                        db.Pelits.Remove(poistettavaPeli);
                        db.SaveChanges();
                        return Ok("Poistettiin peli: " + poistettavaPeli.Nimi);
                    }
                    catch(Exception e)
                    {
                    return BadRequest($"Poistamisessa tapahtui virhe: {e.Message} - {e.InnerException}");
                    }
                }
            else {
                //return NotFound("Peliä id:llä " + id + " ei löydy.");
                // Uudempi tapa liittää merkkijonoon muuttuja-arvoja
                return NotFound($"Peliä id:llä {id} ei löydy.");

            }

        }

        // Pelin tietojen muokkaaminen
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditGame(int id, [FromBody] Pelit peli)
        {
            var muokattavaPeli = db.Pelits.Find(id);
            if (muokattavaPeli != null)
            {
                muokattavaPeli.Nimi = peli.Nimi;
                muokattavaPeli.Tekijä = peli.Tekijä;
                muokattavaPeli.Julkaisuvuosi = peli.Julkaisuvuosi;
                muokattavaPeli.GenreId = peli.GenreId;
                db.SaveChanges();
                return Ok($"Muokattiin peliä {muokattavaPeli.Nimi} ");
            }
            else
            {
                return NotFound($"Peliä id:llä {id} ei löytynyt.");
            }
        }

    }
}
