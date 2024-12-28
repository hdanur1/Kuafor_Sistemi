
using Microsoft.AspNetCore.Mvc;
using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kuafor_Sistemi.Controllers
{
    public class HizmetlerimizController : Controller
    {
        private readonly Context _context;

        // Context nesnesini yapıcı aracılığıyla enjekte ediyoruz.
        public HizmetlerimizController(Context context)
        {
            _context = context;
        }

        public IActionResult HizmetlerVeCalisanlar()
        {
            var model = new HizmetlerCalisanlarViewModel
            {
                Islemler = _context.Islemlers.ToList(),
                Calisanlar = _context.Calisanlars.ToList()
            };

            return View(model);
        }

  
      
    }
}
