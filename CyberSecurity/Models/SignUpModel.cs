using System.ComponentModel.DataAnnotations;

namespace CyberSecurity.Models
{
    public class SignUpModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "USERNAME IS REQUIRED!")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9_]{6,29}$", ErrorMessage = "USERNAME SHOULD CONTAIN ATLEAST 6 CHARACTERS!")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "PASSWORD IS REQUIRED!")]
        [RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,16}$",ErrorMessage = "PASSWORD SHOULD CONTAIN ATLEAST ONE CAPITAL LETTER, ATLEAST ONE SPECIAL CHARACTER, ATLEASE ONE NUMBER!")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "CONFIRM PASSWORD IS REQUIRED!")]
        [Compare("Password", ErrorMessage = "PASSWORD AND CONFIRM PASSWORD DOEST NOT MATCHED!")]
        [RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,16}$", ErrorMessage = "CONFIRM PASSWORD SHOULD CONTAIN ATLEAST ONE CAPITAL LETTER, ATLEAST ONE SPECIAL CHARACTER, ATLEASE ONE NUMBER")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FULL NAME IS REQUIRED!")]
        public string FullName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "EMAIL IS REQUIRED!")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "PLEASE ENTER A VALID EMAIL ADDRES")]
        public string Email { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "MOBILE NUMBER IS REQUIRED!")]
        [RegularExpression("^((\\+)?(977[-]))?(\\d{10}){1}?$", ErrorMessage = "PLEASE ENTER A VALID MOBILE NUMBER")]
        public string MobileNumber { get; set; }
        public string captcha { get; set; }
    }
}
