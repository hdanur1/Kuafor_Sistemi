using Kuafor_Sistemi.Models;
using Kuafor_Sistemi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    private readonly Context _context;
    private readonly KullaniciService _kullaniciService;

    public AccountController(Context context, KullaniciService kullaniciService)
    {
        _context = context;
        _kullaniciService = kullaniciService;
    }


    // Login Sayfası (GET)
    [HttpGet]
    public IActionResult Login(string ReturnUrl = null)
    {
        ViewData["ReturnUrl"] = ReturnUrl;
        return View();
    }


    // Login İşlemi (POST)
    [HttpPost]
    public async Task<IActionResult> Login(string email, string sifre, string returnUrl = null)
    {
        // Kullanıcı doğrulama işlemi
        var kullanici = _kullaniciService.KullaniciDogrula(email, sifre);

        if (kullanici != null)
        {
            // Kullanıcı için Claims oluştur
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, kullanici.KullaniciAd ?? string.Empty),
            new Claim(ClaimTypes.Email, kullanici.Email),
            new Claim(ClaimTypes.Role, kullanici.IsAdmin ? "Admin" : "User")
        };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Kullanıcıyı kimlik doğrulama mekanizmasına dahil et
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // Kullanıcıyı oturumda sakla (isteğe bağlı)
            HttpContext.Session.SetString("EMAIL", kullanici.Email);

            // Kullanıcı adminse admin paneline yönlendir
            if (kullanici.IsAdmin)
            {
                return RedirectToAction("Hizmetler", "Admin");
            }

            // ReturnUrl varsa yönlendir
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            // Varsayılan yönlendirme (kullanıcı ana sayfası)
            return RedirectToAction("Index", "Home");
        }

        // Hatalı giriş durumunda hata mesajını ViewBag'e ekle
        ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
        return View();
    }





    // Kayıt Ol Sayfası (GET)
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // Kayıt Ol İşlemi (POST)
    [HttpPost]
    public IActionResult Register(Kullanicilar kullanici)
    {
        // Yeni kullanıcı admin olamaz
        kullanici.IsAdmin = false;

        // Veritabanına kaydet
        _context.Kullanicilars.Add(kullanici);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    // Çıkış Yap
    public IActionResult Logout()
    {
        // Oturumu temizle
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }


}
