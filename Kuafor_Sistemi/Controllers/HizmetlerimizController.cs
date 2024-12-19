using Microsoft.AspNetCore.Mvc;
using Kuafor_Sistemi.Models;

namespace Kuafor_Sistemi.Controllers
{
    public class HizmetlerimizController : Controller
    {
        public IActionResult Index()
        {
            var degerler = c.islemlers.ToList();
            return View(degerler);
        }
    }
}
