using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TwittersController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TwittersController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("tweets")]
    public IActionResult GetTweets()
    {
        var tweets = new List<object>
        {
            new
            {
                UserId = Guid.NewGuid(),
                Content = "1st tweet"
            },
            new
            {
                UserId = Guid.NewGuid(),
                Content = "2nd tweet"
            },
        };

        return Ok(tweets);
    }


    [HttpGet("app-info")]
    public IActionResult GetAppInfo()
    {
        var appName = _configuration.GetValue<string>("Logging:LogLevel:Default");

        return Ok(new { AppName = appName });
    }

}
