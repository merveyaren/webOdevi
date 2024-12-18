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

        [DataType(DataType.Password)]
        [Compare("sifre", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
