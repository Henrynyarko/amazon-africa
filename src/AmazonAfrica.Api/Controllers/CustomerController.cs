using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly List<CustomerDto> Customers = new List<CustomerDto>
        {
            new CustomerDto { Id = 1, Name = "Kwame Mensah", Email = "kwame@ghanafarmers.com", LoyaltyPoints = 250 },
            new CustomerDto { Id = 2, Name = "Thabo Nkosi", Email = "thabo@safarmers.com", LoyaltyPoints = 500 },
            new CustomerDto { Id = 3, Name = "Amina Toure", Email = "amina@togofarmers.com", LoyaltyPoints = 120 }
        };

        [HttpGet]
        public IActionResult GetAllCustomers() => Ok(Customers);

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = Customers.Find(c => c.Id == id);
            if (customer == null) return NotFound(new { message = "Customer not found" });
            return Ok(customer);
        }
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
    }
}
