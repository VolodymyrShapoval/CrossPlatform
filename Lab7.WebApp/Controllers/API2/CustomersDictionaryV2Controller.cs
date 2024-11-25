using Lab7.WebApp.Database;
using Lab7.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.WebApp.Controllers.API2
{
    [ApiController]
    [Route("api/v2/customers")]
    public class CustomersDictionaryController : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;

        public CustomersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/v2/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            // Додано сортування за прізвищем
            var customers = await _dbContext.Customers
                .OrderBy(c => c.FirstName)
                .ToListAsync();

            return customers == null || customers.Count == 0 ? NotFound() : customers;
        }

        // GET: api/v2/customers/[id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            // Додано інформаційне повідомлення при відсутності запису
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound($"Customer with ID {id} was not found.");

            return customer;
        }

        // POST: api/v2/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer data cannot be null.");

            if (await _dbContext.Customers.AnyAsync(c => c.EmailAddress == customer.EmailAddress))
                return Conflict($"A customer with email {customer.EmailAddress} already exists.");

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = customer.CustomerId },
                customer
            );
        }

        // DELETE: api/v2/customers/[id]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer == null)
                return NotFound($"Customer with ID {id} was not found.");

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return Ok($"Customer with ID {id} has been deleted successfully.");
        }
    }
}
