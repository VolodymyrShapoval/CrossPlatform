using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab6.WebApp.Support;
using System.Net;
using Microsoft.IdentityModel.Logging;
using Lab6.WebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//To use MVC we have to explicitly declare we are using it. Doing so will prevent a System.InvalidOperationException.
builder.Services.AddControllersWithViews();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    options.Scope = "openid email profile phone";
});

// Вибір бази даних
string dbProvider = "SqlLite"; // Змініть на "MSSQL", "Postgres" або "InMemory" за необхідності

// Налаштування DbContext з параметром dbProvider
builder.Services.AddDbContext<CarServiceCenterDbContext>(options =>
{
    switch (dbProvider)
    {
        case "MSSQL":
            options.UseSqlServer("Server=localhost;Database=CarServiceDB;Trusted_Connection=True;");
            break;
        case "Postgres":
            options.UseNpgsql("Host=localhost;Database=CarServiceDB;Username=postgres;Password=postgres;");
            break;
        case "SqlLite":
            options.UseSqlite("Data Source=CarServiceDB.db");
            break;
        case "InMemory":
            options.UseInMemoryDatabase("InMemoryDb");
            break;
        default:
            throw new System.Exception("Unsupported database provider");
    }
});

// Configure the HTTP request pipeline.
builder.Services.ConfigureSameSiteNoneCookies();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();