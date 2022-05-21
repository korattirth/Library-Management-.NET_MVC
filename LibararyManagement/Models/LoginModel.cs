using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibararyManagement.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Must Be required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Must Be required")]
        [DataType(DataType.Password,ErrorMessage ="Please Enter valid Password")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password Should Be Same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}