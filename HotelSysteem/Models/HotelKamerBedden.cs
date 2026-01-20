using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelKamerBedden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BedId { get; set; }
        public virtual HotelKamerBed? Bed { get; set; } = null;
        public int Aantal { get; set; }
        public virtual ICollection<HotelKamerVoorzieningen> Voorzieningen { get; set; } = [];
    }
}
