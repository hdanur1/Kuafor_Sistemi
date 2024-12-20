using Microsoft.AspNetCore.Mvc;
using Kuafor_Sistemi.Models;

namespace Kuafor_Sistemi.Controllers
{
    public class HizmetlerimizController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler=c.Islemlers.ToList();
            return View(degerler);
        }
    }
}
