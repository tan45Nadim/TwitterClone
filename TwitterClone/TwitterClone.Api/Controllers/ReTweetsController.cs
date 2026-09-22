using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReTweetsController : ControllerBase
    {
        // POST: api/retweets/{tweetid}
        [HttpPost("{tweetId}")]
        public IActionResult ReTweet(int tweetId)
        {
            return Ok();
        }

        // DELETE: api/retweets/{tweetid}
        [HttpDelete("{tweetId}")]
        public IActionResult RemoveReTweet(int tweetId)
        {
            return Ok();
        }


    }
}
