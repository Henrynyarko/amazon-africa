using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        // Sample in-memory customer database
        private static readonly List<CustomerDto> Customers = new List<CustomerDto>
        {
            new CustomerDto { Id = 1, Name = "Ernest Nyarko", Email = "ernest@amazonafrica.com", LoyaltyPoints = 450, Status = "Active" },
            new CustomerDto { Id = 2, Name = "Jane Doe", Email = "jane@amazonafrica.com", LoyaltyPoints = 1200, Status = "VIP" },
            new CustomerDto { Id = 3, Name = "John Smith", Email = "john@amazonafrica.com", LoyaltyPoints = 50, Status = "Inactive" }
        };

        // GET: api/customer
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(Customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = Customers.Find(c => c.Id == id);
            if (customer == null) return NotFound(new { message = "Customer not found" });
            return Ok(customer);
        }

        // GET: api/customer/loyalty/{id}
        [HttpGet("loyalty/{id}")]
        public IActionResult GetCustomerLoyaltyPoints(int id)
        {
            var customer = Customers.Find(c => c.Id == id);
            if (customer == null) return NotFound(new { message = "Customer not found" });
            return Ok(new { customer.Id, customer.Name, customer.LoyaltyPoints });
        }
    }

    // DTO (Data Transfer Object) for Customer
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
        public string Status { get; set; } = "Active";
    }
}
