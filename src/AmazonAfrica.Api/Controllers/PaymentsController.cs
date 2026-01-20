using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Payments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private static readonly List<PaymentDto> Payments = new List<PaymentDto>
        {
            new PaymentDto { Id = 5001, OrderId = 1001, CustomerId = 1, Amount = 250.75m, Method = "Credit Card", Status = "Completed", PaymentDate = DateTime.Parse("2026-01-18T09:35:00Z") },
            new PaymentDto { Id = 5002, OrderId = 1002, CustomerId = 2, Amount = 480.00m, Method = "PayPal", Status = "Completed", PaymentDate = DateTime.Parse("2026-01-19T14:20:00Z") },
            new PaymentDto { Id = 5003, OrderId = 1003, CustomerId = 1, Amount = 99.99m, Method = "Credit Card", Status = "Pending", PaymentDate = DateTime.Parse("2026-01-20T08:05:00Z") }
        };

        [HttpGet]
        public IActionResult GetAllPayments() => Ok(Payments);

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = Payments.Find(p => p.Id == id);
            if (payment == null) return NotFound(new { message = "Payment not found" });
            return Ok(payment);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetPaymentsByCustomer(int customerId)
        {
            var customerPayments = Payments.FindAll(p => p.CustomerId == customerId);
            if (customerPayments.Count == 0) return NotFound(new { message = "No payments found for this customer" });
            return Ok(customerPayments);
        }

        [HttpGet("order/{orderId}")]
        public IActionResult GetPaymentsByOrder(int orderId)
        {
            var orderPayments = Payments.FindAll(p => p.OrderId == orderId);
            if (orderPayments.Count == 0) return NotFound(new { message = "No payments found for this order" });
            return Ok(orderPayments);
        }
    }

    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
    }
}
