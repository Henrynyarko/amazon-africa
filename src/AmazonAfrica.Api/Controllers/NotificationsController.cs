using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Notifications.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private static readonly List<NotificationDto> Notifications = new List<NotificationDto>
        {
            new NotificationDto { Id = 1, UserId = 1, Title = "Order Shipped", Message = "Your order #12345 has been shipped.", DateSent = DateTime.Parse("2026-01-18T10:00:00Z"), Read = false },
            new NotificationDto { Id = 2, UserId = 2, Title = "Payment Received", Message = "Payment of $250 has been successfully received.", DateSent = DateTime.Parse("2026-01-19T12:30:00Z"), Read = true },
            new NotificationDto { Id = 3, UserId = 1, Title = "Promotional Offer", Message = "Get 20% off your next purchase!", DateSent = DateTime.Parse("2026-01-20T08:15:00Z"), Read = false }
        };

        [HttpGet]
        public IActionResult GetAllNotifications() => Ok(Notifications);

        [HttpGet("user/{userId}")]
        public IActionResult GetNotificationsForUser(int userId)
        {
            var userNotifications = Notifications.FindAll(n => n.UserId == userId);
            if (userNotifications.Count == 0) return NotFound(new { message = "No notifications for this user" });
            return Ok(userNotifications);
        }

        [HttpGet("unread/{userId}")]
        public IActionResult GetUnreadNotifications(int userId)
        {
            var unread = Notifications.FindAll(n => n.UserId == userId && !n.Read);
            return Ok(unread);
        }
    }

    public class NotificationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime DateSent { get; set; }
        public bool Read { get; set; }
    }
}
