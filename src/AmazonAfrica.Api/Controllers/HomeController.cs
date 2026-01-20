using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AmazonAfrica.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetIndex()
        {
            var dashboard = new
            {
                Message = "Welcome to AmazonAfrica - Your trusted farming ecosystem in Africa.",
                Timestamp = DateTime.UtcNow,
                Countries = new List<object>
                {
                    new 
                    {
                        Name = "Ghana",
                        Customers = 450,
                        Orders = 1200,
                        PaymentsProcessed = 1100,
                        UnreadNotifications = 15,
                        Services = new List<string>
                        {
                            "Customer Management",
                            "Account Management",
                            "Order Processing",
                            "Payment Tracking",
                            "Notifications & Alerts"
                        }
                    },
                    new 
                    {
                        Name = "South Africa",
                        Customers = 520,
                        Orders = 1450,
                        PaymentsProcessed = 1400,
                        UnreadNotifications = 20,
                        Services = new List<string>
                        {
                            "Customer Management",
                            "Account Management",
                            "Order Processing",
                            "Payment Tracking",
                            "Notifications & Alerts"
                        }
                    },
                    new 
                    {
                        Name = "Togo",
                        Customers = 230,
                        Orders = 897,
                        PaymentsProcessed = 710,
                        UnreadNotifications = 10,
                        Services = new List<string>
                        {
                            "Customer Management",
                            "Account Management",
                            "Order Processing",
                            "Payment Tracking",
                            "Notifications & Alerts"
                        }
                    }
                }
            };

            return Ok(dashboard);
        }
    }
}
