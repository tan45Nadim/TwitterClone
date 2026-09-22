using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {

        // POST: api/likes/{tweetId}
        [HttpPost("{tweetId}")]
        public IActionResult LikeTweet(int tweetId)
        {
            return Ok(new {
                message = "Tweet Liked successfully."
            });
        }

        // DELETE: api/likes/{tweetid}
        [HttpDelete("{tweetid}")]
        public IActionResult UnlikeTweet(int tweetid)
        {
            return Ok(new
            {
                message = "Tweet Unliked successfully."
            });
        }

    }
}
