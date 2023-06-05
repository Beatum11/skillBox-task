using System.ComponentModel.DataAnnotations;

namespace ProfiAPI.Data.Models
{
    public class SignUpUser
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare(nameof(Password), ErrorMessage = "Wrong password")]
        public string? ConfirmPassword { get; set; }
    }
}
