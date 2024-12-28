using Kuafor_Sistemi.Migrations;
using Kuafor_Sistemi.Models;

namespace Kuafor_Sistemi.Services
{
    public class KullaniciService
    {
        private readonly Context _context;

        public KullaniciService(Context context)
        {
            _context = context;
        }

        public Kullanicilar KullaniciDogrula(string email, string sifre)
        {
            // Veritabanındaki kullanıcıyı al
            var kullanici = _context.Kullanicilars
                                    .FirstOrDefault(u => u.Email == email && u.Sifre == sifre);

            if (kullanici != null)
            {
                return kullanici;  // Veritabanında kullanıcı varsa, döndür
            }

            // Sabit kullanıcıyı kontrol et
            if (email == "B221210092@ogr.sakarya.edu.tr" && sifre == "sau")
            {
                return new Kullanicilar { Email = "B221210092@ogr.sakarya.edu.tr", IsAdmin = true };
            }

            return null; // Kullanıcı doğrulaması başarısız
        }
    }

}
