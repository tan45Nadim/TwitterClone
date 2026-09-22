using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = new List<object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    Name = "Rahim H",
                    Email = "rahim@gmail.com"
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    Name = "Md. Karim",
                    Email = "karim22@gmail.com"
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    Name = "Abir Ali",
                    Email = "abir@gmail.com"
                }
            };

            return Ok(users);
        }
    }
}
