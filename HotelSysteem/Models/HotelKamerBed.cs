namespace HotelSysteem.Models
{
    public class HotelKamerBed
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public ICollection<HotelKamerBedden> Bedden { get; set; }
    }
}
