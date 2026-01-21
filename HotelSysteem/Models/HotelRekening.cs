using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelRekening
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual ICollection<HotelReservering> Reserveringen { get; set; } = [];
        public int ToeristenBelasting { get; set; }
        public int Korting { get; set; }
        public bool Betaald { get; set; }
    }
}
