using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Oneri
    {
        public int OneriID { get; set; }
        public int KullaniciID { get; set; }
        public string FotoURL { get; set; }
        public string OneriMetni { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Tarih { get; set; }

    }
}
