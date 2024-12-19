﻿using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Kullanicilar
    {
        [Key]
        public int KullaniciID { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }

        public List<Randevular> randevulars { get; set; }
        public List<Oneri> oneris { get; set; }
    }
}
