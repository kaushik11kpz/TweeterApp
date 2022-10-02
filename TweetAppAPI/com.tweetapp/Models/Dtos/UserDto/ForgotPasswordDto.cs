using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Models.Dtos.UserDto
{
    public class ForgotPasswordDto
    {
        [Required]
        public string EmailId { get; set; }

        [Required]
        public int SecurityQuestion { get; set; }

        [Required]
        public string SecurityAnswer { get; set; }
    }
}
