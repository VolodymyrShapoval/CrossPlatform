﻿using Lab7.WebApp.Database.Models;
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), customer.CustomerId);
        }
    }
}
