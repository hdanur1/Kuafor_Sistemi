using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kuafor_Sistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HizmetlerimizApiController : ControllerBase
    {
        private readonly Context _context;

        public HizmetlerimizApiController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetHizmetById(int id)
        {
            var hizmet = _context.Islemlers.Find(id);
            if (hizmet == null)
                return NotFound();

            return Ok(hizmet);
        }

        // POST: api/Hizmetlerimiz
        [HttpPost]
        public IActionResult CreateHizmet([FromBody] Islemler yeniHizmet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Islemlers.Add(yeniHizmet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHizmetById), new { id = yeniHizmet.IslemID }, yeniHizmet);
        }

        // PUT: api/Hizmetlerimiz/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateHizmet(int id, [FromBody] Islemler guncellenmisHizmet)
        {
            if (id != guncellenmisHizmet.IslemID || !ModelState.IsValid)
                return BadRequest();

            var hizmet = _context.Islemlers.Find(id);
            if (hizmet == null)
                return NotFound();

            hizmet.IslemAd = guncellenmisHizmet.IslemAd;
            hizmet.Ucret = guncellenmisHizmet.Ucret;
            hizmet.Sure = guncellenmisHizmet.Sure;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Hizmetlerimiz/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHizmet(int id)
        {
            var hizmet = _context.Islemlers.Find(id);
            if (hizmet == null)
                return NotFound();

            _context.Islemlers.Remove(hizmet);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
