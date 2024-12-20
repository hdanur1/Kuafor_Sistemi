using Microsoft.EntityFrameworkCore;
using Kuafor_Sistemi.Models;

namespace Kuafor_Sistemi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Kullanicilar> Kullanicilar { get; set; }
    }
}