using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        // POST: api/bookmarks/{tweetId}
        [HttpPost("{tweetId}")]
        public IActionResult AddBookmark(int tweetId)
        {
            return Ok(new {message = "Tweet Bookmark successfully."});
        }

        // DELETE: api/bookmarks/{tweetId}
        [HttpDelete("{tweetId}")] 
        public IActionResult RemoveBookmark(int tweetId)
        {
            return Ok();
        }

        // Get: api/bookmarks
        [HttpGet]
        public IActionResult GetAllBookmarks()
        {
            return Ok();
        }

        // DELETE: api/bookmarks
        [HttpDelete]
        public IActionResult RemoveAllBookmarks()
        {
            return Ok();
        }

    }
}
