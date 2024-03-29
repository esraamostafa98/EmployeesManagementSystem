﻿using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class RegisterationVM
    {
        [Required(ErrorMessage ="Mail REQUIRED")]
        [EmailAddress(ErrorMessage ="YOU MUST ADD VALID Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD REQUIRED")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage = "Min len 5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "PASSWORD REQUIRED")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min len 5")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
