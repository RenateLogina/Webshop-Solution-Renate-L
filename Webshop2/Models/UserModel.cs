using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password: ")]
        public string PasswordRepeat { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
