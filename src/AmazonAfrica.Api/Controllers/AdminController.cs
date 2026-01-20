using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AmazonAfrica.Modules.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private static readonly List<AdminDto> Admins = new List<AdminDto>
        {
            new AdminDto { Id = 1, Username = "superadmin", Email = "superadmin@amazonafrica.com", Role = "SuperAdmin", LastLogin = "2026-01-18T09:30:00Z" },
            new AdminDto { Id = 2, Username = "opsmanager", Email = "opsmanager@amazonafrica.com", Role = "OperationsManager", LastLogin = "2026-01-19T14:45:00Z" },
            new AdminDto { Id = 3, Username = "devlead", Email = "devlead@amazonafrica.com", Role = "DeveloperLead", LastLogin = "2026-01-20T08:15:00Z" }
        };

        [HttpGet]
        public IActionResult GetAllAdmins() => Ok(Admins);

        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = Admins.Find(a => a.Id == id);
            if (admin == null) return NotFound(new { message = "Admin not found" });
            return Ok(admin);
        }

        [HttpGet("role/{role}")]
        public IActionResult GetAdminsByRole(string role)
        {
            var filtered = Admins.FindAll(a => a.Role.ToLower() == role.ToLower());
            if (filtered.Count == 0) return NotFound(new { message = "No admins found for this role" });
            return Ok(filtered);
        }
    }

    public class AdminDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string LastLogin { get; set; } = string.Empty;
    }
}
