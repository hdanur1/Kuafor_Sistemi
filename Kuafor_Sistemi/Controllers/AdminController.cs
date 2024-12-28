using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kuafor_Sistemi.Models;

namespace Kuafor_Sistemi.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        public IActionResult Hizmetler()
        {
            // Veritabanından Hizmetlerimizi çekiyoruz.
            var hizmetler = _context.Islemlers.ToList();
            return View(hizmetler);
        }

        [HttpGet]
        public IActionResult HizmetEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HizmetEkle(Islemler yeniHizmet)
        {
          
                _context.Islemlers.Add(yeniHizmet);
                _context.SaveChanges();
                return RedirectToAction("Hizmetler");
       
           
        }

        [HttpGet]
        public IActionResult HizmetGuncelle(int id)
        {
            var hizmet = _context.Islemlers.Find(id);
            if (hizmet == null)
                return NotFound();

            return View(hizmet);
        }

        [HttpPost]
        public IActionResult HizmetGuncelle(Islemler hizmet)
        {

            var mevcutHizmet = _context.Islemlers.Find(hizmet.IslemID);

                    mevcutHizmet.IslemAd = hizmet.IslemAd;
                    mevcutHizmet.Ucret = hizmet.Ucret;
                    mevcutHizmet.Sure = hizmet.Sure;
                    _context.SaveChanges();
                    return RedirectToAction("Hizmetler");
              
        }

        [HttpPost]
        public IActionResult HizmetSil(int id)
        {
            var hizmet = _context.Islemlers.Find(id);
            if (hizmet != null)
            {
                _context.Islemlers.Remove(hizmet);
                _context.SaveChanges();
            }
            return RedirectToAction("Hizmetler");
        }
        public IActionResult Index()
        {
            var messages = _context.Iletisims.OrderByDescending(m => m.SentAt).ToList();
            return View(messages);
        }
       

    }
}
