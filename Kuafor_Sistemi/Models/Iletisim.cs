using System.ComponentModel.DataAnnotations;

namespace Kuafor_Sistemi.Models
{
    public class Iletisim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
