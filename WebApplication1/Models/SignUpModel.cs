using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Enter first name")]
        public string FN { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string LN { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string Gender { get; set; }


        [Required(ErrorMessage =  "Enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeate password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}
