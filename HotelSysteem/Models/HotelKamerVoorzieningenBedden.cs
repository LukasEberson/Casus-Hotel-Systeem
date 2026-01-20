using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelSysteem.Models
{
    public class HotelKamerVoorzieningenBedden
    {
        public int VoorzieningenId { get; set; }
        public int BeddenId { get; set; }
    }
}
