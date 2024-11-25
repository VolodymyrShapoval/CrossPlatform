using Lab7.WebApp.Database;
using Lab7.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab7.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/manufacturers")]
    public class ManufacturersDictionaryController : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public ManufacturersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> Get()
        {
            var manufacturers = await _dbContext.Manufacturers.ToListAsync();
            return manufacturers == null ? NotFound() : manufacturers;
        }

        // GET: api/manufacturers/[id]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Manufacturer>> Get(Guid id)
        {
            var manufacturer = await _dbContext.Manufacturers
                .Include(m => m.Models)
                .FirstOrDefaultAsync(m => m.ManufacturerCode == id);

            return manufacturer == null ? NotFound() : manufacturer;
        }

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Post(Manufacturer manufacturer)
        {
            if (manufacturer == null)
                throw new ArgumentNullException(nameof(manufacturer));

            _dbContext.Manufacturers.Add(manufacturer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = manufacturer.ManufacturerCode },
                manufacturer
            );
        }

        // POST: api/Manufacturers
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacturer>> Delete(Guid id)
        {
            var manufacturer = await _dbContext.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            _dbContext.Manufacturers.Remove(manufacturer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
