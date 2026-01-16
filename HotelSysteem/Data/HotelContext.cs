using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using HotelSysteem.Models;


namespace HotelSysteem.Data
{
    public class HotelContext :DbContext
    {

        public DbSet<Hotelkamer> HotelKamers { get; set; }
        public DbSet<HotelKamerVoorzieningen> Voorzieningens { get; set; }
        public DbSet<HotelKamerBedden> Beddens { get; set; }
        public DbSet<HotelKamerBed> Bedden {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:clmr.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=clmr;Password=back2026!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotelkamer>(builder =>
            {
                builder
                    .HasKey(k => k.Id);

                builder
                    .HasOne(k => k.Voorzieningen)
                    .WithOne(v => v.Kamer)
                    .HasPrincipalKey<Hotelkamer>(k => k.Id)
                    .HasForeignKey<HotelKamerVoorzieningen>(v => v.KamerId);
            });
            modelBuilder.Entity<HotelKamerVoorzieningen>(builder =>
            {
                builder
                    .HasKey(v => v.Id);

                builder
                    .HasMany(v => v.Bedden)
                    .WithMany(b => b.Voorzieningen);
            });
            modelBuilder.Entity<HotelKamerBedden>(builder =>
            {
                builder
                    .HasKey(b => b.Id);

                builder
                    .HasOne(b => b.Bed)
                    .WithMany(b => b.Bedden)
                    .HasPrincipalKey(b => b.Id)
                    .HasForeignKey(b => b.BedId);
            });
            modelBuilder.Entity<HotelKamerBed>(builder =>
            {
                builder
                    .HasKey(b => b.Id);
            });
        }
    }
}
