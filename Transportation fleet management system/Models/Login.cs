using System.ComponentModel.DataAnnotations;

namespace TFMS.Models
{
    public class Login
    {
        // Property for the user's username or email address
        [Required(ErrorMessage = "Username or Email is required.")]
        [Display(Name = "Username or Email")] // Label for UI
        [Key]
        public string UsernameOrEmail { get; set; }

        // Property for the user's password
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)] // Hints to the UI that this is a password field
        public string Password { get; set; }

        // Optional property for 'Remember Me' functionality
        [Display(Name = "Remember Me")] // Label for UI
        public bool RememberMe { get; set; }
    }
}
