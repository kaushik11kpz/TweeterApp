using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.tweetapp.Models.Dtos.UserDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage ="EmailId is Required!")]
        [EmailAddress]
        [BsonElement("emailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "FirstName is Required!")]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        [StringLength(20, ErrorMessage ="Password length must be between 6 to 20", MinimumLength = 6)]
        [BsonElement("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [BsonElement("dateofbirth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is Required!")]
        [BsonElement("gender")]
        public string Gender { get; set; }

        [Required]
        [BsonElement("securityQuestion")]
        public int SecurityQuestion { get; set; }

        [Required]
        [BsonElement("securityAnswer")]
        public string SecurityAnswer { get; set; }
    }
}
