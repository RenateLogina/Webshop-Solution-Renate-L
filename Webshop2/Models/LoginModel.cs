using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class LoginModel

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
    }
}
