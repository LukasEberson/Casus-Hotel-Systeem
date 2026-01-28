using HotelSysteem.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelSysteem.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<HotelRekening> HotelRekeningen { get; set; }
        public DbSet<HotelReservering> HotelReserveringen { get; set; }
        public DbSet<HotelKamerReservering> HotelKamerReserveringen { get; set; }
        public DbSet<HotelKamer> HotelKamers { get; set; }
        public DbSet<HotelKamerTarief> HotelKamerTarieven { get; set; }
        public DbSet<HotelKamerVoorzieningen> Voorzieningens { get; set; }
        public DbSet<HotelKamerBedden> Beddens { get; set; }
        public DbSet<HotelKamerBed> Bedden {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:clmr.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=clmr;Password=back2026!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRekening>(builder =>
            {
                builder
                    .Property(r => r.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(r => r.Id);

                builder
                    .HasMany(r => r.Reserveringen)
                    .WithOne(r => r.Rekening)
                    .HasPrincipalKey(r => r.Id)
                    .HasForeignKey(r => r.RekeningId);
            });

            modelBuilder.Entity<HotelReservering>(builder =>
            {
                builder
                    .Property(r => r.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(r => r.Id);

                builder
                    .HasOne(r => r.Rekening)
                    .WithMany(r => r.Reserveringen)
                    .HasPrincipalKey(r => r.Id)
                    .HasForeignKey(r => r.RekeningId);

                builder
                    .HasMany(r => r.KamerReserveringen)
                    .WithOne(r => r.Reservering)
                    .HasPrincipalKey(r => r.Id)
                    .HasForeignKey(r => r.ReserveringId);
            });

            modelBuilder.Entity<HotelKamerReservering>(builder =>
            {
                builder
                    .Property(r => r.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(r => r.Id);

                builder
                    .HasOne(r => r.Reservering)
                    .WithMany(r => r.KamerReserveringen)
                    .HasPrincipalKey(r => r.Id)
                    .HasForeignKey(r => r.ReserveringId);

                builder
                    .HasOne(r => r.Kamer)
                    .WithMany(k => k.Reserveringen)
                    .HasPrincipalKey(k => k.Id)
                    .HasForeignKey(r => r.KamerId);

                builder
                    .HasOne(r => r.Tarief)
                    .WithMany(t => t.Reserveringen)
                    .HasPrincipalKey(t => t.Id)
                    .HasForeignKey(r => r.TariefId);
            });

            modelBuilder.Entity<HotelKamerTarief>(builder =>
            {
                builder
                    .Property(t => t.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(t => t.Id);

                builder
                    .HasOne(t => t.Kamer)
                    .WithMany(k => k.Tarieven)
                    .HasPrincipalKey(k => k.Id)
                    .HasForeignKey(t => t.KamerId);

                builder
                    .HasMany(t => t.Reserveringen)
                    .WithOne(r => r.Tarief)
                    .HasPrincipalKey(t => t.Id)
                    .HasForeignKey(r => r.TariefId);
            });

            modelBuilder.Entity<HotelKamer>(builder =>
            {
                builder
                    .Property(k => k.Id)
                    .UseIdentityColumn();

                builder
                    .HasKey(k => k.Id);

                builder
                    .HasOne(k => k.Voorzieningen)
                    .WithOne(v => v.Kamer)
                    .HasPrincipalKey<HotelKamer>(k => k.Id)
                    .HasForeignKey<HotelKamerVoorzieningen>(v => v.KamerId);

                builder
                   .HasMany(k => k.Tarieven)
                   .WithOne(t => t.Kamer)
                   .HasPrincipalKey(k => k.Id)
                   .HasForeignKey(t => t.KamerId);

                builder
                    .HasMany(k => k.Reserveringen)
                    .WithOne(r => r.Kamer)
                    .HasPrincipalKey(r => r.Id)
                    .HasForeignKey(k => k.ReserveringId);
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
                    .HasForeignKey<HotelKamer>(k => k.VoorzieningenId);

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
