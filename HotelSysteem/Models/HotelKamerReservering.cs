using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelKamerReservering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ReserveringId { get; set; }
        public virtual HotelReservering? Reservering { get; set; } = null;
        public int KamerId { get; set; }
        public virtual HotelKamer? Kamer { get; set; } = null;
        public int TariefId { get; set; }
        public virtual HotelKamerTarief? Tarief { get; set; } = null;
        public int AantalPersonen { get; set; }
    }
}
