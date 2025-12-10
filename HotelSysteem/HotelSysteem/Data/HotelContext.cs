using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using HotelSysteem.Models;


namespace HotelSysteem.Data
{
    public class HotelContext :DbContext
    {

        public DbSet<Hotelkamer> HotelKamers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelSysteemDb;Trusted_Connection=True;");
        }

    }
}
