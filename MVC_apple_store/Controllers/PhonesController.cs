using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var phones = context.Phones.Include(p => p.Color).ToList(); //MockData.GetPhones();

            return View(phones);
        }

        // GET: /Phones/Manage
        public IActionResult Manage()
        {
            var phones = context.Phones.Include(p => p.Color).ToList();

            return View(phones); // ~Views/Phones/Manage.cshtml
        }

        public IActionResult Create()
        {
            var colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name));

            // Type Conversion code is required while enumerating.
            // ViewData["ColorList"] = colors;

            // In depth, ViewBag is used dynamic, so there is no need to type conversion while enumerating.
            ViewBag.ColorList = colors;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                var colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name));
                ViewBag.ColorList = colors;
                return View(phone);
            }

            context.Phones.Add(phone);
            context.SaveChanges();

            TempData["ToastrMessage"] = "Phone was created sucessfully!";

            return RedirectToAction(nameof(Manage));
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

            return RedirectToAction(nameof(Manage));
        }
    }
}
