using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webOdevi.Models;

namespace webOdevi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<musteriler> Musteriler { get; set; }
        public DbSet<personel> Personel { get; set; }
        public DbSet<services> Services { get; set; }
        public DbSet<randevular> Randevular { get; set; }
        public DbSet<randevuonay> RandevuOnay { get; set; }
        public DbSet<uygunluk> Uygunluk { get; set; }
        public DbSet<admin> Admin { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base sınıfın OnModelCreating metodunu çağırıyoruz
            base.OnModelCreating(modelBuilder);

            // Özel ayarlar ve ilişkiler ekleme (ihtiyaca göre)
            modelBuilder.Entity<admin>().ToTable("admin");
            modelBuilder.Entity<musteriler>().ToTable("musteriler");
            modelBuilder.Entity<personel>().ToTable("personel");
            modelBuilder.Entity<services>().ToTable("services");
            modelBuilder.Entity<randevular>().ToTable("randevular");
            modelBuilder.Entity<randevuonay>().ToTable("randevuonay");
            modelBuilder.Entity<uygunluk>().ToTable("uygunluk");
            // Admin rolü ekleme
            
            // İlişkileri ekleme
            modelBuilder.Entity<randevular>()
                .HasOne(m => m.Musteri)   // Randevular'ın Musteriler ile ilişkisi
                .WithMany()
                .HasForeignKey(r => r.musteriid);

            modelBuilder.Entity<randevular>()
                .HasOne(p => p.Personel)  // Randevular'ın Personel ile ilişkisi
                .WithMany()
                .HasForeignKey(r => r.personelid);

            modelBuilder.Entity<randevular>()
                .HasOne(h => h.Hizmet)    // Randevular'ın Services ile ilişkisi
                .WithMany()
                .HasForeignKey(r => r.hizmetid);

            modelBuilder.Entity<randevuonay>()
                .HasOne(p => p.Personel)       // RandevuOnay'ın Personel ile ilişkisi
                .WithMany()
                .HasForeignKey(r => r.onaylayancalisan);

            modelBuilder.Entity<randevuonay>()
                .HasOne(r => r.Randevu)      // RandevuOnay'ın Randevular ile ilişkisi
                .WithMany()
                .HasForeignKey(r => r.randevuid);

            modelBuilder.Entity<uygunluk>()
                .HasOne(p => p.Personel)    // Uygunluk'un Personel ile ilişkisi
                .WithMany()
                .HasForeignKey(u => u.personelid);

        }
    }
}

