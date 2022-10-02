using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_apple_store.Models;
using System.Diagnostics;

namespace MVC_apple_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreDbContext context;

        public HomeController(StoreDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var phones = context.Phones.Include(p => p.Color).ToList();
            return View(phones);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}