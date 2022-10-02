using com.tweetapp.Models.Dtos.TweetDto;
using com.tweetapp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace com.tweetapp.Controllers
{
    [Route("api/v1.0/tweets")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;
        public TweetController(ITweetService userService)
        {
            _tweetService = userService;
        }

        /// <summary>
        /// Get all tweets
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTweets()
        {
            var response = await _tweetService.GetAllTweets();
            if (response != null) { return Ok(response); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });

        }

        /// <summary>
        /// Get all user's tweet
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetAllTweetOfUsers(string userName)
        {
            var response = await _tweetService.GetUsersTweet(userName);
            if (response != null) { return Ok(response); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }

        /// <summary>
        /// post a new tweet
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tweet"></param>
        /// <returns></returns>

        [HttpPost("{userName}/add")]
        public async Task<IActionResult> PostTweet(string userName, [FromBody] CreateTweetDto tweet)
        {
            if (!ModelState.IsValid) { return StatusCode(400, ModelState); }
            var response = await _tweetService.PostTweet(userName, tweet);
            if (response != null) { return StatusCode(201, response); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }

        /// <summary>
        /// delete tweet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTweet(string id)
        {
            var response = await _tweetService.DeleteTweet(id);
            if (response) { return StatusCode(204, new { msg = "Resource deleted sucessfully" }); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }

        /// <summary>
        /// Reply on a  tweet
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="id"></param>
        /// <param name="replyText"></param>
        /// <returns></returns>
        [HttpPut("{userName}/reply/{id}")]
        public async Task<IActionResult> ReplyTweet(string userName,string id,[FromBody] CreateTweetDto replyText)
        {
            if (!ModelState.IsValid) { return StatusCode(400, ModelState); }
            var response = await _tweetService.Reply(id, replyText.TweetText, userName);
            return StatusCode(201, response);
        }

        /// <summary>
        /// update tweet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedText"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTweet(string id, [FromBody] CreateTweetDto updatedText)
        {
            if (!ModelState.IsValid) { return StatusCode(400, ModelState); }
            var response = await _tweetService.UpdateTweet(id, updatedText.TweetText);
            if(response != null) { return StatusCode(201, response); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }

        /// <summary>
        /// Get tweet by tweet id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("tweet/{id}")]
        public async Task<IActionResult> GetTweetByTweetId(string id)
        {
            var response = await _tweetService.GetTweetByTweetId(id);
            if (response!=null) { return Ok(response); }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }

        /// <summary>
        /// Like and Unlike a tweet
        /// </summary>
        /// <param name="tweetId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("{userId}/like/{tweetId}")]
        public async Task<IActionResult> LlikeUnlikeTweet(string tweetId, string userId)
        {
            var response = await _tweetService.LikeOrUnlikeTweet(tweetId, userId);
            if(response >= 0)
            {
                return Ok(response);
            }
            return StatusCode(500, new { errorMessage = "Internal Server Error!" });
        }
    }
}
