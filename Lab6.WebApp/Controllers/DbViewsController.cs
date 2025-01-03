﻿using Azure;
using Lab6.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
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
    }
}
