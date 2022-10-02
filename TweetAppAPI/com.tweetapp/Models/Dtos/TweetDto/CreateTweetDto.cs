using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Models.Dtos.TweetDto
{
    public class CreateTweetDto
    {
        [Required(ErrorMessage = "Tweet Text is required")]
        [StringLength(144, ErrorMessage = "Tweet  must be less than 144 characters!")]
        [BsonElement("tweetText")]
        public string TweetText { get; set; }

    }
}
