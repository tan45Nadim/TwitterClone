using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {

        private readonly TweetRepository _tweetRepository; 
        private readonly UserRepository _userRepository;

        public TweetsController(TweetRepository tweetRepository, UserRepository userRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }

        // api/tweets
        [HttpGet()]
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

            var tweetDtos = tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId,
            });

            return Ok(tweetDtos);
        }

        // api/tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound("tweet not found");
            }

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId,
            };

            return Ok(tweetDto);
        }

        // api/tweets
        [HttpPost()]    
        public IActionResult CreateTweet([FromBody] CreateTweetRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Content))
            {
                return BadRequest("content is required");
            }

            var user = _userRepository.GetUserById(req.UserId);

            if (user == null)
            {
                return NotFound("user not found");
            }

            var tweet = new Tweet(req.Content)
            {
                UserId = req.UserId
            };

            _tweetRepository.AddTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId,
            };

            return Ok(tweetDto);

        }

        // api/tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetRequest req)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound("tweet not found");
            }

            tweet.Content = req.Content;

            _tweetRepository.UpdateTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId,
            };

            return Ok(tweetDto);
        }

        // api/tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound("tweet not found");
            }

            _tweetRepository.DeleteTweet(tweet);

            return Ok(new
            {
                message = "tweet deleted successfully"
            });
        }

    }
}
