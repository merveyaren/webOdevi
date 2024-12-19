using Microsoft.AspNetCore.Identity;

namespace webOdevi.Models
{
    public class musteriler : IdentityUser
    {
        public int musteriid { get; set; }
        public string musteriadi { get; set; }
        public string musterisoyadi { get; set; }
        public string musteritelefon { get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }
    }
}
