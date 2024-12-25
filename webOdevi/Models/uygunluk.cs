using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace webOdevi.Models
{
    public class uygunluk
    {
        [Key]
        [Column("uygunlukid")]
        public int uygunlukid { get; set; }

        [Column("personelid")]
        public int personelid { get; set; }

        [Column("tarih")]

        [DataType(DataType.Date)] // Tarihin tarih türünde olduğunu belirtir
        public DateTime tarih { get; set; }

        [Column("baslangicsaati")]

        [DataType(DataType.Time)] // Başlangıç saatinin zaman türünde olduğunu belirtir
        public TimeSpan baslangicsaati { get; set; }

        [Column("bitissaati")]

        [DataType(DataType.Time)] // Bitiş saatinin zaman türünde olduğunu belirtir
        public TimeSpan bitissaati { get; set; }

        // Doğru ForeignKey kullanımı
        [ForeignKey("personelid")]
        public personel Personel { get; set; }
    }
}
