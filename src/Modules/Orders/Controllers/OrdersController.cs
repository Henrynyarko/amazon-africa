using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Orders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        // Sample in-memory orders database
        private static readonly List<OrderDto> Orders = new List<OrderDto>
        {
            new OrderDto { Id = 1001, CustomerId = 1, TotalAmount = 250.75m, Status = "Shipped", OrderDate = DateTime.Parse("2026-01-18T09:30:00Z") },
            new OrderDto { Id = 1002, CustomerId = 2, TotalAmount = 480.00m, Status = "Delivered", OrderDate = DateTime.Parse("2026-01-19T14:15:00Z") },
            new OrderDto { Id = 1003, CustomerId = 1, TotalAmount = 99.99m, Status = "Processing", OrderDate = DateTime.Parse("2026-01-20T08:00:00Z") }
        };

        // GET: api/orders
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(Orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = Orders.Find(o => o.Id == id);
            if (order == null) return NotFound(new { message = "Order not found" });
            return Ok(order);
        }

        // GET: api/orders/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public IActionResult GetOrdersByCustomer(int customerId)
        {
            var customerOrders = Orders.FindAll(o => o.CustomerId == customerId);
            if (customerOrders.Count == 0) return NotFound(new { message = "No orders found for this customer" });
            return Ok(customerOrders);
        }
    }

    // DTO (Data Transfer Object) for Order
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty; // e.g., Processing, Shipped, Delivered
        public DateTime OrderDate { get; set; }
    }
}
