using Microsoft.AspNetCore.Mvc;

namespace Lab6.WebApp.Controllers
{
    public class CarsTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
