namespace HotelSysteem.Models
{
    public class HotelKamerVoorzieningenBedden
    {
        public int VoorzieningenId { get; set; }
        public HotelKamerVoorzieningen Voorzieningen { get; set; }
        public int BeddenId { get; set; }
        public HotelKamerBedden Bedden { get; set; }
    }
}
