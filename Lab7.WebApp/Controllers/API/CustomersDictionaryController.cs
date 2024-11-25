using Lab7.WebApp.Database.Models;
using Lab7.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Lab7.WebApp.Controllers.API.V1
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersDictionaryController : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;

        public CustomersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/v1/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers == null ? NotFound() : customers;
        }

        // GET: api/v1/customers/[id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            return customer == null ? NotFound() : customer;
        }

        // POST: api/v1/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = customer.CustomerId },
                customer
            );
        }

        // DELETE: api/v1/customers/[id]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(Guid id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

