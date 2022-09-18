using Microsoft.AspNetCore.Mvc;
using MVC_apple_store.Data;
using MVC_apple_store.Models;

namespace MVC_apple_store.Controllers
{
    public class PhonesController : Controller
    {
        public IActionResult Index()
        {
            var phones = MockData.GetPhones();

            return View(phones);
        }

        public IActionResult Details(int id)
        {
            var phone = MockData.GetPhones().FirstOrDefault(p => p.Id == id);
            return View(phone);
        }
    }
}
