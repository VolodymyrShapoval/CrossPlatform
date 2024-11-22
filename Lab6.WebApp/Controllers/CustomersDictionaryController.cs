using Lab6.WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class CustomersDictionaryController : Controller
    {
        private readonly CarServiceCenterDbContext _dbContext;
        public CustomersDictionaryController(CarServiceCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return View(customers);
        }
    }
}
