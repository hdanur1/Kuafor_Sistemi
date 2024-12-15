using Microsoft.EntityFrameworkCore;

namespace Kuafor_Sistemi.Models
{
    public class Context: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-JJBSGN9K\\SQLEXPRESS; database=DbKuafor ; integrated security=true;");
        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Calisanlar> calisanlars { get; set; }

        public DbSet<Islemler> islemlers { get; set; }

        public DbSet<Kullanicilar> kullanicilars { get; set; }

        public DbSet<Oneri> oneris { get; set; }

        public DbSet<Randevular> randevulars { get; set; }


    }
}
