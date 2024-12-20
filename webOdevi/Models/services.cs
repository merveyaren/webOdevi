using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webOdevi.Models
{
    public class services
    {
        [Key]
        [Column("hizmetid")]
        public int hizmetid { get; set; }

        [Column("hizmetadi")]
        [Required]
        [StringLength(100)] // 100 karakter uzunluğunda
        public string hizmetadi { get; set; }

        [Column("fiyat")]
        [Required]
        [DataType(DataType.Currency)] // Fiyatın para biçiminde olduğunu belirtir
        public decimal fiyat { get; set; }
    }
}
