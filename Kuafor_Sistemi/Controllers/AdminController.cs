using Microsoft.AspNetCore.Mvc;

namespace Kuafor_Sistemi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
