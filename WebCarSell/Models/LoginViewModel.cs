using System.ComponentModel.DataAnnotations;

namespace WebCarSell.Models
{
    public class LoginViewModel
    {
        
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Roles { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}

