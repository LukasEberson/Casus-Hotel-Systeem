using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelKamerVoorzieningen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? KamerId { get; set; }
        public virtual Hotelkamer? Kamer { get; set; } = null;
        public virtual ICollection<HotelKamerBedden>? Bedden { get; set; } = [];
        public int Oppervlakte { get; set; }
        public bool Balkon {  get; set; }
        public int Badkamers { get; set; }
        public int Slaapkamers { get; set; }
    }
}
