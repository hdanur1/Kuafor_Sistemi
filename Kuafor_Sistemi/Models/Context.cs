using Microsoft.EntityFrameworkCore;

namespace Kuafor_Sistemi.Models
{
    public class Context : DbContext
    {
        // Parametreli constructor
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Calisanlar> Calisanlars { get; set; }
        public DbSet<Islemler> Islemlers { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<Oneri> Oneris { get; set; }
        public DbSet<Randevular> Randevulars { get; set; }
    }
}
