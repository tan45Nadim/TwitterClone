using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // GET: api/notifications
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok();
        }

        // DELETE: api/notifications/{notificationId}
        [HttpDelete("{notificationId}")]
        public IActionResult DeleteNotification(int notificationId)
        {
            return Ok();
        }

        // DELETE: api/notifications/
        [HttpDelete]
        public IActionResult DeleteAllNotification(int notificationId)
        {
            return Ok();
        }

    }
}
