using Lab6.WebApp.Database;
using Lab6.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers.API
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
            var manufacturers = await _dbContext.Manufacturers
                .Include(m => m.Models)
                .ToListAsync();

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
    }
}
