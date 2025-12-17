namespace HotelSysteem.Models
{
    public class HotelKamerVoorzieningen
    {
        public int Id { get; set; }
        public int KamerId { get; set; }
        public Hotelkamer Kamer { get; set; }
        public ICollection<HotelKamerBedden> Bedden { get; set; }
        public int Oppervlakte { get; set; }
        public bool Balkon {  get; set; }
        public int Badkamers { get; set; }
        public int Slaapkamers { get; set; }
    }
}
