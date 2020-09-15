﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo_Test.Models
{
    public partial class Client
    {
        public Client()
        {
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please input first name!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please input email!")]
        [EmailAddress(ErrorMessage = "Please input right email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input password")]
        [MinLength(8, ErrorMessage = "Password Minimun 8 Character!")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Password must be a combination of upper case, lower case and number!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please choose gender!")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please input your age!")]
        public int Age { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
