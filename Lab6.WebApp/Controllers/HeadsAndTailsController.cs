using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab4.Library;
using System.Security.Cryptography;
using System.IO;
using System;

namespace Lab6.WebApp.Controllers
{
    public class HeadsAndTailsController : Controller
    {
        // GET: HeadsAndTailsController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculate(string n, string m)
        {            
            try
            {
                string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\input.txt");
                string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\output.txt");
                // Перевіряємо, чи існує файл, і створюємо його, якщо ні
                if (!System.IO.File.Exists(inputFilePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(inputFilePath));
                    System.IO.File.Create(inputFilePath).Dispose();
                    System.IO.File.Create(outputFilePath).Dispose();
                }

                // Записуємо значення змінних n та m у файл
                System.IO.File.WriteAllText(inputFilePath, $"{n} {m}");

                LabsLibrary.ExecuteLab(1, inputFilePath, outputFilePath);

                string outputContent = System.IO.File.ReadAllText(outputFilePath);
                ViewData["Result"] = outputContent;
            }
            catch
            {
                ViewData["Result"] = "Помилка: невірні дані";
            }

            return View("Index");
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
