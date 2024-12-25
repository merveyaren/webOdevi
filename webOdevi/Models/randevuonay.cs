using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    [Table("randevuonay")] // Tablo ismini belirten öznitelik
    public class randevuonay
    {
        [Key] // Primary key olarak işaretler
        [Column("onayid")] // Tablo kolon adı ile eşleştirilir
        public int onayid { get; set; }

        [Column("randevuid")]
         // NOT NULL
        public int randevuid { get; set; }

        [Column("onaydurum")]
        
        [StringLength(20)] // 20 karakter uzunluğunda olduğunu belirtir
        public string onaydurum { get; set; }

        [Column("onaytarihi")]
        
        public DateTime onaytarihi { get; set; }

        [Column("onaylayancalisan")]
        
        public int onaylayancalisan { get; set; }

        // İlişki tanımlamaları
        [ForeignKey("onaylayancalisan")]
        public personel Personel { get; set; }

        [ForeignKey("randevuid")]
        public randevular Randevu { get; set; }
    }
}
