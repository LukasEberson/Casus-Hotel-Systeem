using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelKamerTarief
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? KamerId { get; set; }
        public virtual HotelKamer? Kamer { get; set; } = null;
        public DateOnly GeldingVan { get; set; }
        public DateOnly GeldigTot { get; set; }
        public int Tarief { get; set; }
        public virtual ICollection<HotelKamerReservering> Reserveringen { get; set; } = [];
    }
}
