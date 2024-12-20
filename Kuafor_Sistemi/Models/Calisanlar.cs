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

        [DataType(DataType.Time)]
        public TimeSpan MusaitlikBaslangic { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan MusaitlikBitis { get; set; }

       public List<Randevular> Randevulars { get; set; }
    }
}
