using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Adınız en az 2 en fazla 50 karakter olabilir!")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Adınız en az 2 en fazla 50 karakter olabilir!")]
        [Display(Name = "Soyadınız:")]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
