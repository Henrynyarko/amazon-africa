using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Account.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly List<AccountDto> Accounts = new List<AccountDto>
        {
            new AccountDto { Id = 1, CustomerId = 1, Balance = 1250.50m, Status = "Active" },
            new AccountDto { Id = 2, CustomerId = 2, Balance = 980.75m, Status = "Active" },
            new AccountDto { Id = 3, CustomerId = 3, Balance = 0m, Status = "Inactive" }
        };

        [HttpGet]
        public IActionResult GetAllAccounts() => Ok(Accounts);

        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            var account = Accounts.Find(a => a.Id == id);
            if (account == null) return NotFound(new { message = "Account not found" });
            return Ok(account);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetAccountByCustomer(int customerId)
        {
            var account = Accounts.Find(a => a.CustomerId == customerId);
            if (account == null) return NotFound(new { message = "No account found for this customer" });
            return Ok(account);
        }
    }

    public class AccountDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
