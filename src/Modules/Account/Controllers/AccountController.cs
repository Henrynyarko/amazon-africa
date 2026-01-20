using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Account.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        // Sample in-memory accounts database (for demo purposes)
        private static readonly List<AccountDto> Accounts = new List<AccountDto>
        {
            new AccountDto { Id = 1, Name = "Ernest Nyarko", Email = "ernest@amazonafrica.com", Balance = 1250.50m },
            new AccountDto { Id = 2, Name = "Jane Doe", Email = "jane@amazonafrica.com", Balance = 980.75m },
            new AccountDto { Id = 3, Name = "John Smith", Email = "john@amazonafrica.com", Balance = 4320.00m }
        };

        // GET: api/account
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            return Ok(Accounts);
        }

        // GET: api/account/{id}
        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            var account = Accounts.Find(a => a.Id == id);
            if (account == null) return NotFound(new { message = "Account not found" });
            return Ok(account);
        }

        // GET: api/account/balance/{id}
        [HttpGet("balance/{id}")]
        public IActionResult GetAccountBalance(int id)
        {
            var account = Accounts.Find(a => a.Id == id);
            if (account == null) return NotFound(new { message = "Account not found" });
            return Ok(new { account.Id, account.Name, account.Balance });
        }
    }

    // DTO (Data Transfer Object) for account
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
