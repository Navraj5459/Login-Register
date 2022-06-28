using System.ComponentModel.DataAnnotations;

namespace CyberSecurity.Models
{
    public class UserDetailModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
