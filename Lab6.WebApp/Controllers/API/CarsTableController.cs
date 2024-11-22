﻿using Lab6.WebApp.Database.Models;
using Lab6.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Lab6.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/cars")]
    public class CarsTableController : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public CarsTableController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            var cars = await _dbContext.Cars
                .Include(c => c.Model)
                .Include(c => c.Customer)
                .ToListAsync();

            return cars == null ? NotFound() : cars;
        }

        // GET: api/cars/[id]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Car>> Get(Guid id)
        {
            var car = await _dbContext.Cars
                .Include(c => c.ServiceBookings)
                .FirstOrDefaultAsync(c => c.LicenceNumber == id);

            return car == null ? NotFound() : car;
        }
    }
}