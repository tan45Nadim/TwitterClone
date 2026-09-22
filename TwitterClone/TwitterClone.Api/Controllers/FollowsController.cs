using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FollowsController : ControllerBase
{
    
    // GET: api/follows/followers/{userID}
    [HttpGet("followers/{userId}")]
    public IActionResult GetFollowers(int userId)
    {
        return Ok();
    }

    // GET: api/follows/following/{userID}
    [HttpGet("following/{userId}")]
    public IActionResult GetFollowing(int userId)
    {
        return Ok();
    }

    // POST: api/follows/{userId}
    [HttpPost("{userId}")]
    public IActionResult FollowUser(int userId)
    {
        return Ok(new
        {
            message = "User Followed."
        });
    }

    // DELETE: api/follows/{userId}
    [HttpDelete("{userId}")]
    public IActionResult UnfollowUser(int userId)
    {
        return Ok(new
        {
            message = "User Unfollowed."
        });
    }


}