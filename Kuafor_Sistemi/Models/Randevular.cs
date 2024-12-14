using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Randevular
    {

        [Key]
        public int RandevuID { get; set; }
        public int CalisanID { get; set; }
        public int KullaniciID { get; set; }
        public int IslemID { get; set; }
        public int TarihSaat { get; set; }
        public int ToplamUcret { get; set; }


    }
}
