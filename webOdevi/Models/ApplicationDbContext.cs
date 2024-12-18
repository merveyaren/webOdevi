using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webOdevi.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<personel> Personel { get; set; }
        public DbSet<musteriler> Musteriler { get; set; }
        public DbSet<services> Services { get; set; }
        public DbSet<randevular> Randevular { get; set; }
        public DbSet<randevuonay> RandevuOnay { get; set; }
        public DbSet<uygunluk> Uygunluk { get; set; }
    }
}
