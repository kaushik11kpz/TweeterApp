using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Models
{
    public class ReplyTweets
    {
        [Required]
        [BsonElement("replyText")]
        public string ReplyText { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("dateAndTimeOfReply")]
        public DateTime? DateAndTimeOfReply { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }
    }
}
