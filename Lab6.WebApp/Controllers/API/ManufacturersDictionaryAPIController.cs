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

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> Get()
        {
            return await _dbContext.Manufacturers
                .Include(m => m.Models)
                .ToListAsync();
        }

        // GET: api/Manufacturers/[id]
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
