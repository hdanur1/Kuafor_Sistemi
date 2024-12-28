using Microsoft.AspNetCore.Mvc;
using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kuafor_Sistemi.Controllers
{
    
    public class IletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Context _context;

        public IletisimController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Submit(string Name, string Email, string Subject, string Message)
        {
            if (ModelState.IsValid)
            {
                // Yeni mesaj oluştur
                var contactMessage = new Iletisim
                {
                    Name = Name,
                    Email = Email,
                    Subject = Subject,
                    Message = Message,
                    SentAt = DateTime.Now
                };

                // Veritabanına kaydet
                _context.Iletisims.Add(contactMessage);
                _context.SaveChanges();

                TempData["Success"] = "Mesajınız başarıyla gönderildi. Teşekkür ederiz!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Mesajınız gönderilirken bir hata oluştu.";
            return RedirectToAction("Index");
        }



    }
}
