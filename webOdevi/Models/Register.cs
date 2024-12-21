using System.ComponentModel.DataAnnotations;

namespace webOdevi.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string eposta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string sifre { get; set; }


        [Required]
        public string musteriadi { get; set; }

        [Required]
        public string musterisoyadi { get; set; }

        [Required]
        public string musteritelefon { get; set; }
    }
}
