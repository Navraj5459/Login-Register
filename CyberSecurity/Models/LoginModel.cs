using System.ComponentModel.DataAnnotations;

namespace CyberSecurity.Models
{
    public class LoginModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "USERNAME IS REQUIRED!")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "PASSWORD IS REQUIRED!")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
