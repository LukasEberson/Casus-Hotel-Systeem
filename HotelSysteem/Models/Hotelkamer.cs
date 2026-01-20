//using System.ComponentModel.DataAnnotations;
// Je zou eventueel dit kunnen gebruiken zodat je voor de public int ID [Key] kunt zetten om te laten weten dat dit de primary key is.
// Daarnaast kan je voor andere properties ook data annotations gebruiken zoals [Required] --> dit laat zien dat deze property verplicht is.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysteem.Models
{
    public class Hotelkamer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get ; set; }
        public int Nummer { get ; set; }
        public int VoorzieningenId { get; set; }
        public virtual HotelKamerVoorzieningen? Voorzieningen { get; set; } = null;
    }
}
