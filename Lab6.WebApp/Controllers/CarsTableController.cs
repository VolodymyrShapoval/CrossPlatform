using Lab6.WebApp.Database;
using Lab6.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class CarsTableController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/cars");
                var jsonData = await httpResponse.Content.ReadAsStringAsync();

                if (jsonData == null) throw new JsonException("There are not any information");
                var cars = JsonSerializer.Deserialize<List<Car>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(cars);
            }
            catch
            {
                return View();
            }
        }
    }
}
