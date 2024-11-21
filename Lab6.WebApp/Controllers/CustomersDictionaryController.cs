using Microsoft.AspNetCore.Mvc;

namespace Lab6.WebApp.Controllers
{
    public class CustomersDictionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
