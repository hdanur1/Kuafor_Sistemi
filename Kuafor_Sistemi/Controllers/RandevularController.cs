using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kuafor_Sistemi.Controllers
{
    public class RandevularController : Controller
    {
        private readonly Context _context;

        public RandevularController(Context context)
        {
            _context = context;
        }

        // Randevu alma sayfası (GET)
        public IActionResult Create()
        {
            ViewBag.Islemler = _context.Islemlers.ToList(); // İşlemler listesini doldur
            ViewBag.Calisanlar = _context.Calisanlars.ToList(); // Çalışanlar listesini doldur
            return View();
        }

        
      [HttpPost]
        public IActionResult Create(Randevular model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı oturum kontrolü
                var kullaniciId = HttpContext.Session.GetString("KullaniciID");
                if (kullaniciId == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                // Çakışan randevu kontrolü
                bool randevuVarMi = _context.Randevulars.Any(r =>
                    r.CalisanID == model.CalisanID &&
                    r.TarihSaat == model.TarihSaat);

                if (randevuVarMi)
                {
                    ModelState.AddModelError("", "Bu tarih ve saatte seçilen kuaförde başka bir randevu bulunmaktadır.");
                    ViewBag.Islemler = _context.Islemlers.ToList();
                    ViewBag.Calisanlar = _context.Calisanlars.ToList();
                    return View(model);
                }

                // Kullanıcı ID'sini ve örnek bir toplam ücreti ata
                model.KullaniciID = int.Parse(kullaniciId);
                 // Bu değeri işlemlere veya farklı bir hesaplamaya göre değiştirebilirsiniz

                // Randevuyu kaydet
                _context.Randevulars.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            ViewBag.Islemler = _context.Islemlers.ToList();
            ViewBag.Calisanlar = _context.Calisanlars.ToList();
            return View(model);
        }


        // Başarılı randevu alımı sonrası yönlendirme
        public IActionResult Success()
        {
            return View();
        }
    }
}
