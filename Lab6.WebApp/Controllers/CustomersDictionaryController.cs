using Lab6.WebApp.Database;
using Lab6.WebApp.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab6.WebApp.Controllers
{
    public class CustomersDictionaryController : Controller
    {
        public async Task<IActionResult> Index()
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

                return View(customers);
            }
            catch
            {
                return View();
            }
        }
    }
}
