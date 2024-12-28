using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdevi.Models
{
    public class admin
    {
        [Key]
        [Column("adminid")]
        public int adminid { get; set; }

        [Column("eposta")]
        [EmailAddress] // E-posta format doğrulaması
        public string eposta { get; set; }

        [Column("sifre")]
        public string sifre { get; set; }
    }
}
