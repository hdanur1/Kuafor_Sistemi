using Microsoft.EntityFrameworkCore;

namespace Kuafor_Sistemi.Models
{
    public class Context: DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<Calisanlar> calisanlars { get; set; }

        public DbSet<Islemler> islemlers { get; set; }

        public DbSet<Kullanicilar> kullanicilars { get; set; }

        public DbSet<Oneri> oneris { get; set; }

        public DbSet<Randevular> randevulars { get; set; }


    }
}
