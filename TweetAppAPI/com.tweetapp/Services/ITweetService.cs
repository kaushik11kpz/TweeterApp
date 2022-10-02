using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.TweetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Services
{
    public interface ITweetService
    {
        public Task<IEnumerable<Tweets>> GetAllTweets();

        public Task<IEnumerable<Tweets>> GetUsersTweet(string userId);

        public Task<bool> Reply(string tweetId, string tweetText, string userId);

        public Task<bool> DeleteTweet(string tweetId);

        public Task<Tweets> PostTweet(string userId, CreateTweetDto tweet);

        public Task<Tweets> UpdateTweet(string tweetId, string text);

        public Task<Tweets> GetTweetByTweetId(string id);

        public Task<int> LikeOrUnlikeTweet(string tweetId, string userId);

    }
}
