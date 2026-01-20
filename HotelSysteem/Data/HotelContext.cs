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
                    .Property(k => k.Id)
                    .UseIdentityColumn();

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
                    .Property(v => v.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(v => v.Id);

                builder
                    .HasOne(v => v.Kamer)
                    .WithOne(k => k.Voorzieningen)
                    .HasPrincipalKey<HotelKamerVoorzieningen>(v => v.Id)
                    .HasForeignKey<Hotelkamer>(k => k.VoorzieningenId);

                builder
                    .HasMany(v => v.Bedden)
                    .WithMany(b => b.Voorzieningen)
                    .UsingEntity<HotelKamerVoorzieningenBedden>()
                    .ToTable("HotelKamerBeddenHotelKamerVoorzieningen");

                builder
                    .Property(v => v.KamerId)
                    .IsRequired(false);
            });
            modelBuilder.Entity<HotelKamerBedden>(builder =>
            {
                builder
                    .Property(b => b.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(b => b.Id);

                builder
                    .HasOne(b => b.Bed)
                    .WithMany(b => b.Bedden)
                    .HasPrincipalKey(b => b.Id)
                    .HasForeignKey(b => b.BedId);

                builder
                    .HasMany(b => b.Voorzieningen)
                    .WithMany(v => v.Bedden)
                    .UsingEntity<HotelKamerVoorzieningenBedden>()
                    .ToTable("HotelKamerBeddenHotelKamerVoorzieningen");
            });
            modelBuilder.Entity<HotelKamerBed>(builder =>
            {
                builder
                    .Property(b => b.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(b => b.Id);
            });
        }
    }
}
