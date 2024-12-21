using System.ComponentModel.DataAnnotations;

namespace webOdevi.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string eposta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string sifre { get; set; }
    }
}
