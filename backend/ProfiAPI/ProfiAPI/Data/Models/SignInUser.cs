using System.ComponentModel.DataAnnotations;

namespace ProfiAPI.Data.Models
{
    public class SignInUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}
