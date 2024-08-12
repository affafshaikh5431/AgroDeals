using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.ViewModel
{
    public class LoginViewModel
    {


        [Display(Name = "UserName [Email]")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(60, ErrorMessage = "Max 60 chars allowed")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}