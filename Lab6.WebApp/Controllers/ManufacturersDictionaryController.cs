using Lab6.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class ManufacturersDictionaryController : Controller
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public ManufacturersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var manufacturers = await _dbContext.Manufacturers.ToListAsync();
            return View(manufacturers);
        }
    }
}
