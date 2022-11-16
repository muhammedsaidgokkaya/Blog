using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class KullaniciGirisDto
    {
        [Required(ErrorMessage = "lüften kullancı adı giriniz.")]
        public string username { get; set; }

        [Required(ErrorMessage = "lütfen şifrenizi giriniz.")]
        public string password { get; set; }
    }
}
