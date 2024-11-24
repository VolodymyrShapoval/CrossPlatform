using Lab7.WebApp.Database.Models;
using Lab7.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Lab7.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersDictionaryController : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public CustomersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers == null ? NotFound() : customers;
        }

        // GET: api/customers/[id]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            return customer == null ? NotFound() : customer;
        }

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Post([FromBody] Manufacturer manufacturer)
        {
            if (manufacturer == null)
                throw new ArgumentNullException(nameof(manufacturer));

            _dbContext.Manufacturers.Add(manufacturer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), manufacturer.ManufacturerCode);
        }
    }
}
