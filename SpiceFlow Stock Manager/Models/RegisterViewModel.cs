//Author: Krish Patel

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SpiceFlow_Stock_Manager.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("(?i)^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.(com|ca)$", ErrorMessage = "Email must contain '@' and end with .com or .ca")]
        [Remote(action: "IsEmailAvailable", controller: "Account", ErrorMessage = "Email is already in use")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$", ErrorMessage = "Postal code must be in the format A1A 1A1")]
        public string? PostalCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Phone number must be 10 digits (e.g. 416-555-1234)")]
        public string? PhoneNumber { get; set; }
    }
}
