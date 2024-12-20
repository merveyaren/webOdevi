using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    [Table("personel")] // Veritabanı tablosunu belirtir
    public class personel
    {
        [Key] // Primary key olarak işaretler
        [Column("personelid")] // Kolon adı eşleştirilir
        public int personelid { get; set; }

        [Column("personeladi")]
        [Required]
        [StringLength(50)] // Maksimum uzunluk 50
        public string personeladi { get; set; }

        [Column("personelsoyadi")]
        [Required]
        [StringLength(50)]
        public string personelsoyadi { get; set; }

        [Column("pozisyon")]
        [Required]
        [StringLength(100)]
        public string pozisyon { get; set; }

        [Column("personeltelefon")]
        [Required]
        [StringLength(15)]
        public string personeltelefon { get; set; }

        [Column("personeleposta")]
        [Required]
        [StringLength(100)]
        public string personeleposta { get; set; }

        [Column("isebaslamatarihi")]
        [Required] // NOT NULL belirtir
        public DateTime isebaslamatarihi { get; set; }
    }
}
