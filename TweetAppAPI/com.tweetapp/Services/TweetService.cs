using AutoMapper;
using com.tweetapp.Data.IRepository;
using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.TweetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweet;
        private readonly IMapper _mapper;
        private readonly IUserRepository _user;
        public TweetService(ITweetRepository tweet, IMapper mapper, IUserRepository user)
        {
            _tweet = tweet;
            _mapper = mapper;
            _user = user;
        }

        public async Task<bool> DeleteTweet(string tweetId)
        {
            try
            {
                return await _tweet.DeleteTweet(tweetId);
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public async Task<IEnumerable<Tweets>> GetAllTweets()
        {
            try
            {
                var tweets = await _tweet.GetAllTweets();
                if (tweets != null)
                {
                    return tweets.OrderByDescending(m => m.DateAndTimeOfTweet);
                }
                return tweets;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<Tweets>> GetUsersTweet(string userId)
        {
            try
            {
                var tweets =  await _tweet.GetUsersTweet(userId);
                if (tweets != null)
                {
                    return tweets.OrderByDescending(m => m.DateAndTimeOfTweet);
                }
                return tweets;

            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<bool> Reply(string tweetId, string tweetText, string userId)
        {
            try
            {
                var useDetail = await _user.GetUserAsync(userId);
                ReplyTweets reply = new ReplyTweets { ReplyText = tweetText, UserId = userId , DateAndTimeOfReply = DateTime.Now, FirstName = useDetail.FirstName, LastName = useDetail.LastName};
                return await _tweet.Reply(tweetId, reply);
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<Tweets> PostTweet(string userId, CreateTweetDto tweet)
        {
            try
            {
                var result = _mapper.Map<Tweets>(tweet);
                var userDetail = await _user.GetUserAsync(userId);
                result.Likes = 0;
                result.UserId = userId;
                result.Replies = new List<ReplyTweets>();
                result.FirstName = userDetail.FirstName;
                result.LastName = userDetail.LastName;
                result.DateAndTimeOfTweet = DateTime.Now;
                result.LikedBy = new string[] { };
                return await _tweet.PostTweet(result);
            }
            catch(Exception ex)
            {
                return null;
            }
           
         
        }

        public async Task<Tweets> UpdateTweet(string tweetId, string text)
        {
            try
            {
                return await _tweet.UpdateTweet(tweetId, text);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Tweets> GetTweetByTweetId(string id)
        {
            try
            {
                return await _tweet.GetTweetByTweetId(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> LikeOrUnlikeTweet(string tweetId, string userId)
        {
            try
            {
                return await _tweet.LikeOrUnlikeTweet(tweetId, userId);
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
