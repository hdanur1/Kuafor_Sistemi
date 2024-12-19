using Microsoft.EntityFrameworkCore;

namespace Kuafor_Sistemi.Models
{
    public class Context: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-JJBSGN9K\\SQLEXPRESS; database=DbKuafor ; integrated security=true;");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Calisanlar> Calisanlars { get; set; }

        public DbSet<Islemler> Islemlers { get; set; }

        public DbSet<Kullanicilar> Kullanicilars { get; set; }

        public DbSet<Oneri> Oneris { get; set; }

        public DbSet<Randevular> Randevulars { get; set; }


    }
}
