using Lab4.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace Lab6.WebApp.Controllers
{
    public class MysticChessController : Controller
    {
        // GET: MysticChessController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculate(string cells)
        {
            try // ОБОВ'ЯЗКОВО ЗМІНИТИ НА НОРМАЛЬНУ УМОВУ
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

                // Записуємо значення змінних у файл
                System.IO.File.WriteAllText(inputFilePath, cells);

                LabsLibrary.ExecuteLab(3, inputFilePath, outputFilePath);

                string outputContent = System.IO.File.ReadAllText(outputFilePath);
                ViewData["Result"] = outputContent;
            }
            catch
            {
                ViewData["Result"] = "Помилка: невірні дані";
            }

            return View("Index");
        }

        // GET: MysticChessController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MysticChessController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MysticChessController/Create
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

        // GET: MysticChessController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MysticChessController/Edit/5
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

        // GET: MysticChessController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MysticChessController/Delete/5
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
