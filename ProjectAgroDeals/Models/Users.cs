using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{

    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Full Name")]
        [StringLength(80, ErrorMessage = "Max 80 Characters Allowed!")]
        [Required(ErrorMessage = "Full Name Required")]
        public string FullName { get; set; }

        [Display(Name = "UserName [Email]")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(50, ErrorMessage = "Max 50 chars allowed")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Mobile No cannot be of 11 Digits")]
        [Required(ErrorMessage = "Mobile No Required")]
        public string MobileNo { get; set; }


        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(50, ErrorMessage = "Max 50 Character Required")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        


        [Display(Name = "Role")]
        [Required(ErrorMessage = "Select Role")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Role")]
        public int RoleID { get; set; }



        [ForeignKey("RoleID")]
        public virtual Roles Roles { get; set; }

       


    }
}