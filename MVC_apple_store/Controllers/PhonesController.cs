using DataAccess;
using Microsoft.AspNetCore.Mvc;
using MVC_apple_store.Models;

namespace MVC_apple_store.Controllers
{
    public class PhonesController : Controller
    {
        private readonly StoreDbContext context;

        public PhonesController(StoreDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var phones = context.Phones.ToList(); //MockData.GetPhones();

            return View(phones);
        }

        public IActionResult Manage()
        {
            var phones = context.Phones.ToList();

            return View(phones);
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var phone = context.Phones.Find(id); //MockData.GetPhones().FirstOrDefault(p => p.Id == id);

            if (phone == null) return NotFound();

            return View(phone);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var phone = context.Phones.Find(id);

            if (phone == null) return NotFound();

            context.Phones.Remove(phone);
            context.SaveChanges();

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
