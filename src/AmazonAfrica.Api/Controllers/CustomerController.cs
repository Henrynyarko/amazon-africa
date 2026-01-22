[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    // Existing GET endpoints
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
            return NotFound(new { message = "Customer not found" });

        return Ok(customer);
    }

    // NEW: Add a customer
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    // NEW: Update an existing customer
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
    {
        var existing = await _context.Customers.FindAsync(id);
        if (existing == null)
            return NotFound(new { message = "Customer not found" });

        existing.Name = customer.Name;
        existing.Email = customer.Email;
        existing.LoyaltyPoints = customer.LoyaltyPoints;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
