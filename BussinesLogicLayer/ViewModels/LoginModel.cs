using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.ViewModels
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
