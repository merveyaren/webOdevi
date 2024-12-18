namespace webOdevi.Models
{
    public class uygunluk
    {
        public int uygunlukId { get; set; }
        public int personelId { get; set; }
        public DateTime tarih { get; set; }
        public TimeSpan baslangicSaati { get; set; }
        public TimeSpan bitisSaati { get; set; }
    }
}
