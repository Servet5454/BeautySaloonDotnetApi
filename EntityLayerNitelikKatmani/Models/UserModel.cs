﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayerNitelikKatmani.Models
{
    public class UserModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string? UserPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare(nameof(UserPassword), ErrorMessage = "Passwords do not match.")]
        //[RegularExpression(@"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&.])[A-Za-z\d$@$!%*?&.]{6, 15}/",
        //    ErrorMessage = "Please enter at least 1 uppercase, 1 lowercase, 1 special character, and maximum 15 characters.")] 
        public string? UserPassword2 { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string? Surname { get; set; }

        public bool IsOwner { get; set; } = false;

        public string? Color { get; set; }
    }
}
