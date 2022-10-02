using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.tweetapp.Models
{
    public class Tweets
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage ="Tweet Text is required")]
        [StringLength(144, ErrorMessage ="Tweet  must be less than 144 characters!")]
        [BsonElement("tweetText")]
        public string TweetText { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("dateAndTimeOfTweet")]
        public DateTime? DateAndTimeOfTweet { get; set; }

        [BsonElement("likes")]
        public int Likes { get; set; }

        [BsonElement("replies")]
        public List<ReplyTweets> Replies { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("likedBy")]
        public string[] LikedBy { get; set; }

    }
}
