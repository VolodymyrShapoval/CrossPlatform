using Azure;
using Lab7.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab7.WebApp.Controllers
{
    public class DbViewsController : Controller
    {
        public async Task<IActionResult> ManufacturersDictionary()
        {
            try
            {
                using var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/manufacturers");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return View("Views/ManufacturersDictionary/Index.cshtml", new List<Manufacturer>());
                }

                var jsonData = await httpResponse.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                var manufacturers = JsonSerializer.Deserialize<List<Manufacturer>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("Views/ManufacturersDictionary/Index.cshtml", manufacturers);
            }
            catch
            {
                return View("Views/ManufacturersDictionary/Index.cshtml", new List<Manufacturer>());
            }
        }

        public async Task<IActionResult> CustomersDictionary()
        {
            try
            {
                using var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/customers");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
                }

                var jsonData = await httpResponse.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                var customers = JsonSerializer.Deserialize<List<Customer>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("Views/CustomersDictionary/Index.cshtml", customers);
            }
            catch
            {
                return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
            }
        }

        public async Task<IActionResult> CarsTable()
        {
            try
            {
                using var httpClient = new HttpClient();

                var httpResponse = await httpClient.GetAsync("http://localhost:3000/api/cars");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return View("Views/CarsTable/Index.cshtml", new List<Car>());
                }

                var jsonData = await httpResponse.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                var cars = JsonSerializer.Deserialize<List<Car>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (cars == null || !cars.Any())
                {
                    return View("Views/CarsTable/Index.cshtml", new List<Car>());
                }

                return View("Views/CarsTable/Index.cshtml", cars);
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while fetching car data. Please try again later.";
                return View("Views/CarsTable/Index.cshtml", new List<Car>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> CarsTableSearch(string query)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"http://localhost:3000/api/cars/search?query={query}");

                if (!response.IsSuccessStatusCode)
                {
                    return View("Views/CarsTable/Index.cshtml", new List<Car>());
                }

                var jsonData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                var cars = JsonSerializer.Deserialize<List<Car>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("Views/CarsTable/Index.cshtml", cars);
            }
            catch
            {
                return View("Views/CarsTable/Index.cshtml", new List<Car>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CustomerAdd([FromForm] Customer customer)
        {
            try
            {
                using var httpClient = new HttpClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(customer),
                    Encoding.UTF8,
                    "application/json"
                );
                var response = await httpClient.PostAsync("http://localhost:3000/api/customers", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
                }

                var jsonData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                return RedirectToAction("CustomersDictionary", "DbViews");
            }
            catch
            {
                return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManufacturerAdd([FromForm] Manufacturer manufacturer)
        {
            try
            {
                using var httpClient = new HttpClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(manufacturer),
                    Encoding.UTF8,
                    "application/json"
                );
                var response = await httpClient.PostAsync("http://localhost:3000/api/manufacturers", content);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Views/ManufacturerDictionary/Index.cshtml", new List<Manufacturer>());
                }

                var jsonData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    throw new JsonException("Received empty data from the API.");
                }

                return RedirectToAction("ManufacturersDictionary", "DbViews");
            }
            catch
            {
                return View("Views/ManufacturerDictionary/Index.cshtml", new List<Manufacturer>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CustomerDelete(Guid id)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.DeleteAsync($"http://localhost:3000/api/customers/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
                }

                return RedirectToAction("CustomersDictionary", "DbViews");
            }
            catch
            {
                return View("Views/CustomersDictionary/Index.cshtml", new List<Customer>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManufacturerDelete(Guid id)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.DeleteAsync($"http://localhost:3000/api/manufacturers/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return View("Views/ManufacturerDictionary/Index.cshtml", new List<Manufacturer>());
                }

                return RedirectToAction("ManufacturersDictionary", "DbViews");
            }
            catch
            {
                return View("Views/ManufacturerDictionary/Index.cshtml", new List<Manufacturer>());
            }
        }
    }
}
