using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    public class services
    {
        [Key]
        [Column("hizmetid")]
        public int hizmetid { get; set; }

        [Column("hizmetadi")]
        [StringLength(100)] // Maksimum 100 karakter
        public string hizmetadi { get; set; }

        [Column("fiyat")]
        public decimal fiyat { get; set; }

        [Column("sure")]
        public int sure { get; set; } // Hizmet süresi, dakika cinsinden tutulur
    }
}
