using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HeadsAndTailsController : Controller
    {
        // GET: HeadsAndTailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HeadsAndTailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HeadsAndTailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadsAndTailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeadsAndTailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeadsAndTailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeadsAndTailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeadsAndTailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
