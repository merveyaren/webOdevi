namespace webOdevi.Models
{
    public class randevular
    {
        public int randevuId { get; set; }
        public int musteriId { get; set; }
        public int personelId { get; set; }
        public int hizmetId { get; set; }
        public DateTime randevuTarihi { get; set; }
        public TimeSpan baslangicSaati { get; set; }
        public TimeSpan bitisSaati { get; set; }
        public string durum { get; set; }
    }
}
