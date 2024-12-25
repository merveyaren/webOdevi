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

        [Required]
        [Column("musteriid")]
         // NOT NULL
        public int musteriid { get; set; }

        [Required]
        [Column("personelid")]
        
        public int personelid { get; set; }

        [Required]
        [Column("hizmetid")]
        
        public int hizmetid { get; set; }

        [Column("randevutarihi")]
        
        public DateTime? randevutarihi { get; set; }

        [Column("baslangicsaati")]
        
        public TimeSpan? baslangicsaati { get; set; }


        [Column("durum")]
        
        [StringLength(20)] // 20 karakter uzunluğunda olduğunu belirtir
        public string durum { get; set; } = "Bekliyor";

        // İlişki tanımlamaları
        [ForeignKey("hizmetid")]
        public services Hizmet { get; set; }

        [ForeignKey("musteriid")]
        public musteriler Musteri { get; set; }

        [ForeignKey("personelid")]
        public personel Personel { get; set; }
    }
}
