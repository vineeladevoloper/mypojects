using Microsoft.AspNetCore.Mvc;
using taskmanagement2.DTOS;
using taskmanagement2.services;
using static taskmanagement2.Irepos.ICommentNotification;

namespace taskmanagement2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentNotificationController : ControllerBase
    {
        private readonly ICommentNotificationService commentNotificationService;

        public CommentNotificationController(ICommentNotificationService commentNotificationService)
        {
            this.commentNotificationService = commentNotificationService;
        }

        [HttpPost("add")]
        public IActionResult AddCommentNotification([FromBody] CommentNotificationDTO notificationDTO)
        {
            try
            {
                commentNotificationService.AddCommentNotification(notificationDTO);
                return Ok("Comment notification added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllCommentNotifications()
        {
            try
            {
                var notifications = commentNotificationService.GetAllCommentNotifications();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetCommentNotificationsByUser(string userId)
        {
            try
            {
                var notifications = commentNotificationService.GetCommentNotificationsByUser(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("markAsRead/{commentNotificationId}")]
        public IActionResult MarkAsRead(int commentNotificationId)
        {
            try
            {
                commentNotificationService.MarkAsRead(commentNotificationId);
                return Ok($"Comment notification with ID {commentNotificationId} marked as read.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
