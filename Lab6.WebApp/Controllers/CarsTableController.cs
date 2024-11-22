using Lab6.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class CarsTableController : Controller
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public CarsTableController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _dbContext.Cars
                .Include(c => c.Model)
                .Include(c => c.Customer)
                .ToListAsync();
            return View(cars);
        }
    }
}
