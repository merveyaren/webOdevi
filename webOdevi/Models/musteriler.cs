using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    [Table("musteriler")] // Veritabanı tablosunu belirtir
    public class musteriler
    {
        [Key] // Primary key olarak işaretler
        [Column("musteriid")] // Kolon adı eşleştirilir
        public int musteriid { get; set; }

        [Column("musteriadi")]
        [Required]
        [StringLength(50)]
        public string musteriadi { get; set; }

        [Column("musterisoyadi")]
        [Required]
        [StringLength(50)]
        public string musterisoyadi { get; set; }

        [Column("musteritelefon")]
        [Required]
        [StringLength(15)]
        public string musteritelefon { get; set; }

        [Column("eposta")]
        [Required]
        [StringLength(100)]
        public string eposta { get; set; }

        [Column("sifre")]
        public string sifre { get; set; }
    }
}
