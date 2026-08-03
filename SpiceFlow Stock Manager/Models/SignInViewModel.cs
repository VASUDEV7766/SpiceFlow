//Author: Krish Patel

using System.ComponentModel.DataAnnotations;

namespace SpiceFlow_Stock_Manager.Models
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
