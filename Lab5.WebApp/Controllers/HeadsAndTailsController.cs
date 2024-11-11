﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DoodleJumpController : Controller
    {
        // GET: DoodleJumpController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DoodleJumpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoodleJumpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoodleJumpController/Create
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

        // GET: DoodleJumpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoodleJumpController/Edit/5
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

        // GET: DoodleJumpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoodleJumpController/Delete/5
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
