using Lab7.WebApp.Database.Models;
using Lab7.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab7.WebApp.Controllers.API
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

        // GET: api/cars/search
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<List<Car>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Search term cannot be empty.");
            }

            var cars = await _dbContext.Cars
                .Include(c => c.Model)
                .Include(c => c.Customer)
                .Where(c => c.Model.ModelName.Contains(query)
                        || c.Customer.FirstName.Contains(query)
                        || c.Customer.LastName.Contains(query))
                .ToListAsync();

            if (cars.Count == 0)
            {
                return NotFound("No cars found matching the search term.");
            }

            return Ok(cars);
        }
    }
}
