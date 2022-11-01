using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestapiDath.Models;

namespace RestapiDath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenretController : ControllerBase
    {

        PeliDBContext db = new PeliDBContext();

        [HttpGet]
        public ActionResult getAll()
        {
            var genret = db.Genrets.ToList();
            return Ok(genret);
        }

        [HttpPost]
        public ActionResult AddNew([FromBody] Genret newGenre)
        {
            db.Genrets.Add(newGenre);
            db.SaveChanges();
            return Ok("Lisättiin uusi genre nimellä " + newGenre.Nimi);
        }

        // Genren poistaminen
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Remove(int id)
        {
            var poistettava = db.Genrets.Find(id);
            if (poistettava != null)
            {

                try
                {
                    db.Genrets.Remove(poistettava);
                    db.SaveChanges();
                    return Ok("Poistettiin genre: " + poistettava.Nimi);
                }
                catch (Exception e)
                {
                    return BadRequest($"Poistamisessa tapahtui virhe. Onkohan Genre käytössä jossain pelissä? Tai: {e.Message} - {e.InnerException}");
                }
            }
            else
            {
                //return NotFound("Peliä id:llä " + id + " ei löydy.");
                // Uudempi tapa liittää merkkijonoon muuttuja-arvoja
                return NotFound($"Genreä id:llä {id} ei löydy.");

            }

        }

    }
}
