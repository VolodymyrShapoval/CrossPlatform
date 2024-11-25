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
    [Route("api/v2/manufacturers")]
    public class ManufacturersDictionaryV2Controller : ControllerBase
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public ManufacturersDictionaryV2Controller(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/v2/manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> Get([FromQuery] string? name = null)
        {
            var query = _dbContext.Manufacturers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => EF.Functions.Like(m.ManufacturerName, $"%{name}%"));
            }

            var manufacturers = await query.ToListAsync();

            return manufacturers.Any() ? manufacturers : NotFound();
        }

        // GET: api/v2/manufacturers/[id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> Get(Guid id)
        {
            var manufacturer = await _dbContext.Manufacturers
                .Include(m => m.Models)
                .FirstOrDefaultAsync(m => m.ManufacturerCode == id);

            return manufacturer != null ? manufacturer : NotFound();
        }

        // POST: api/v2/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Post(Manufacturer manufacturer)
        {
            if (manufacturer == null)
                return BadRequest("Manufacturer cannot be null.");

            if (await _dbContext.Manufacturers.AnyAsync(m => m.ManufacturerCode == manufacturer.ManufacturerCode))
            {
                return Conflict($"A manufacturer with the code {manufacturer.ManufacturerCode} already exists.");
            }

            _dbContext.Manufacturers.Add(manufacturer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = manufacturer.ManufacturerCode },
                manufacturer
            );
        }

        // DELETE: api/v2/Manufacturers/[id]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
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
