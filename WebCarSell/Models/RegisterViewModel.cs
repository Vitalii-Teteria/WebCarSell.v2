using System.ComponentModel.DataAnnotations;

namespace WebCarSell.Models
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string? Roles { get; set; }
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? SName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
