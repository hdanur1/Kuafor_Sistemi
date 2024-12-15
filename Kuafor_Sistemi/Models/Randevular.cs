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
        [DataType(DataType.DateTime)]
        public DateTime TarihSaat { get; set; }
        public float ToplamUcret { get; set; }


    }
}
