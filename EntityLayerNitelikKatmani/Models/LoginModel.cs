using System;

using System.ComponentModel.DataAnnotations;



namespace EntityLayerNitelikKatmani.Models
{
    public class LoginModel
    {
        [Required]
        public string? UserPassword { get; set; }

        [Required(ErrorMessage ="Email adress cannot be null")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? UserEmail { get; set; }
    }
}
