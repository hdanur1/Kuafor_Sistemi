using System.ComponentModel.DataAnnotations;
namespace Kuafor_Sistemi.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public bool IsAdmin { get; set; }
    }
}
