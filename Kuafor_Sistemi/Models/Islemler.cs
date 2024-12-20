using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Islemler
    {
        [Key]
        public int IslemID { get; set; }
        public string IslemAd { get; set; }

        public float Ucret { get; set; }

        public int Sure { get; set; }

        public List<Randevular> Randevulars { get; set; }
    }
}
