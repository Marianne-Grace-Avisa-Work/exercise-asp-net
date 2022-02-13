using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegisterLoginLogout.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please input your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please input your email address")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please input a valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please input your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}