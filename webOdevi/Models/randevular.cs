using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    [Table("randevular")] // Tablo ismini belirten öznitelik
    public class randevular
    {
        [Key] // Primary key olarak işaretler
        [Column("randevuid")] // Tablo kolon adı ile eşleştirilir
        public int randevuid { get; set; }

        [Column("musteriid")]
        [Required] // NOT NULL
        public int musteriid { get; set; }

        [Column("personelid")]
        [Required]
        public int personelid { get; set; }

        [Column("hizmetid")]
        [Required]
        public int hizmetid { get; set; }

        [Column("randevutarihi")]
        [Required]
        public DateTime randevutarihi { get; set; }

        [Column("baslangicsaati")]
        [Required]
        public TimeSpan baslangicsaati { get; set; }

        [Column("bitissaati")]
        [Required]
        public TimeSpan bitissaati { get; set; }

        [Column("durum")]
        [Required]
        [StringLength(20)] // 20 karakter uzunluğunda olduğunu belirtir
        public string durum { get; set; }

        // İlişki tanımlamaları
        [ForeignKey("hizmetid")]
        public services Hizmet { get; set; }

        [ForeignKey("musteriid")]
        public musteriler Musteri { get; set; }

        [ForeignKey("personelid")]
        public personel Personel { get; set; }
    }
}
