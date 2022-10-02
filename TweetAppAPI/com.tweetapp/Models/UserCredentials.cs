using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Models
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "EmailId is Required!")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        [StringLength(20, ErrorMessage = "Password length must be between 6 to 20", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
