using com.tweetapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Data.IRepository
{
    public interface ITweetRepository
    {
        public Task<IEnumerable<Tweets>> GetAllTweets();

        public Task<IEnumerable<Tweets>> GetUsersTweet(string userId);

        public Task<bool> Reply(string tweetId, ReplyTweets reply);

        public Task<bool> DeleteTweet(string tweetId);

        public Task<Tweets> PostTweet(Tweets tweet);

        public Task<Tweets> UpdateTweet(string tweetId, string text);

        public Task<Tweets> GetTweetByTweetId(string tweetId);

        public Task<int> LikeOrUnlikeTweet(string tweetId, string userId);
    }
}
