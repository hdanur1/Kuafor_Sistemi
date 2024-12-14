using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Calisanlar
    {
        [Key]
        public int CalisanID { get; set; }

        public string CalisanAd { get; set; }

        public string CalisanSoyad { get; set; }

        public string Uzmanlik { get; set; }

        public int MusaitlikBaslangic { get; set; }

        public int  MusaitlikBitis  { get; set; }

    }
}
