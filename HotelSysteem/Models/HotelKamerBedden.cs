namespace HotelSysteem.Models
{
    public class HotelKamerBedden
    {
        public int Id { get; set; }
        public int BedId { get; set; }
        public HotelKamerBed Bed { get; set; }
        public int Aantal { get; set; }
        public ICollection<HotelKamerVoorzieningen> Voorzieningen { get; set; }
    }
}
