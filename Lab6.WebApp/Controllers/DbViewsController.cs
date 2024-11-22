using Lab6.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class DbViewsController : Controller
    {
        public async Task<IActionResult> ManufacturersDictionary()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/manufacturers");
                var jsonData = await httpResponse.Content.ReadAsStringAsync();

                if (jsonData == null) throw new JsonException("There are not any information");
                var manufacturers = JsonSerializer.Deserialize<List<Manufacturer>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("Views/ManufacturersDictionary/Index.cshtml", manufacturers);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> CustomersDictionary()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/customers");
                var jsonData = await httpResponse.Content.ReadAsStringAsync();

                if (jsonData == null) throw new JsonException("There are not any information");
                var customers = JsonSerializer.Deserialize<List<Customer>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("Views/CustomersDictionary/Index.cshtml", customers);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> CarsTable()
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

                return View("Views/CarsTable/Index.cshtml", cars);
            }
            catch
            {
                return View();
            }
        }
    }
}
