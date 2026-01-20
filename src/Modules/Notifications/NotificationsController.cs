using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Notifications.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        // Sample in-memory notifications database
        private static readonly List<NotificationDto> Notifications = new List<NotificationDto>
        {
            new NotificationDto { Id = 1, UserId = 1, Title = "Order Shipped", Message = "Your order #12345 has been shipped.", DateSent = DateTime.Parse("2026-01-18T10:00:00Z"), Read = false },
            new NotificationDto { Id = 2, UserId = 2, Title = "Payment Received", Message = "Payment of $250 has been successfully received.", DateSent = DateTime.Parse("2026-01-19T12:30:00Z"), Read = true },
            new NotificationDto { Id = 3, UserId = 1, Title = "Promotional Offer", Message = "Get 20% off your next purchase!", DateSent = DateTime.Parse("2026-01-20T08:15:00Z"), Read = false }
        };

        // GET: api/notifications
        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            return Ok(Notifications);
        }

        // GET: api/notifications/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetNotificationsForUser(int userId)
        {
            var userNotifications = Notifications.FindAll(n => n.UserId == userId);
            if (userNotifications.Count == 0) return NotFound(new { message = "No notifications for this user" });
            return Ok(userNotifications);
        }

        // GET: api/notifications/unread/{userId}
        [HttpGet("unread/{userId}")]
        public IActionResult GetUnreadNotifications(int userId)
        {
            var unread = Notifications.FindAll(n => n.UserId == userId && !n.Read);
            if (unread.Count == 0) return Ok(new List<NotificationDto>()); // return empty list if none
            return Ok(unread);
        }
    }

    // DTO (Data Transfer Object) for Notification
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
