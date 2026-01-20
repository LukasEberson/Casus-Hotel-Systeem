using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class HotelKamerBed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public virtual ICollection<HotelKamerBedden> Bedden { get; set; } = [];
    }
}
