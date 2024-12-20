using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Randevular
    {

        [Key]
        public int RandevuID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TarihSaat { get; set; }
        public float ToplamUcret { get; set; }

        public int IslemID{ get; set; }
        public int CalisanID { get; set; }
        public int KullaniciID { get; set; }

        public Islemler Islem {  get; set; }
        public Calisanlar Calisan {  get; set; }
        public Kullanicilar Kullanici { get; set; }



    }
}
