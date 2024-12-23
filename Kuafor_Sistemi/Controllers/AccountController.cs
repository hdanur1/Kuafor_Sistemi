using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly Context _context;

    public AccountController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Email, string Sifre)
    {
        var kullanici = _context.Kullanicilars.SingleOrDefault(u => u.Email == Email && u.Sifre == Sifre);
        if (kullanici != null)
        {
            HttpContext.Session.SetString("KullaniciID", kullanici.KullaniciID.ToString());
            HttpContext.Session.SetString("IsAdmin", kullanici.IsAdmin.ToString());

            if (kullanici.IsAdmin)
            {
                return RedirectToAction("AdminDashboard", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid email or password.";
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Kullanicilar kullanici)
    {
        kullanici.IsAdmin = false; // Yeni kullanıcılar admin olmayacak.
        _context.Kullanicilars.Add(kullanici);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
