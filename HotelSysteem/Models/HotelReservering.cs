using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelReservering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RekeningId { get; set; }
        public virtual HotelRekening? Rekening { get; set; } = null;
        public string Naam { get; set; }
        public string Emailaddres { get; set; }
        public string TelefoonNummer { get; set; }
        public DateOnly BeginDatum { get; set; }
        public DateOnly EindDatum { get; set; }
        public virtual ICollection<HotelKamerReservering> KamerReserveringen { get; set; } = [];
    }
}
