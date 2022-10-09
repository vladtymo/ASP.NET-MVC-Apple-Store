using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_apple_store.Helpers;
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

        // GET: /Phones/Index or /Phones
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

        // GET: /Phones/Details/{id}
        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var phone = context.Phones.Find(id); //MockData.GetPhones().FirstOrDefault(p => p.Id == id);

            if (phone == null) return NotFound();

            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();
            ViewBag.IsInCart = IsInCart(id);

            return View(phone);
        }
        private bool IsInCart(int id)
        {
            var productIds = HttpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return false;

            return productIds.Contains(id);
        }

        // GET: /Phones/Create
        public IActionResult Create()
        {
            var colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name));

            // ViewData - type Conversion code is required while enumerating
            // ViewData["ColorList"] = colors;

            // ViewBag - used dynamic, so there is no need to type conversion while enumerating
            ViewBag.ColorList = colors;

            return View();
        }

        // POST: /Phones/Create
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

            TempData[WebConstants.alertMsgKey] = "Phone was created successfully!";

            return RedirectToAction(nameof(Manage));
        }

        // GET: /Phones/Edit/{id}
        public IActionResult Edit(int id)
        {
            if (id < 0) return BadRequest();

            var phone = context.Phones.Find(id);

            if (phone == null) return NotFound();

            var colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name));
            ViewBag.ColorList = colors;

            return View(phone);
        }

        // POST: /Phones/Edit
        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                var colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name));
                ViewBag.ColorList = colors;
                return View(phone);
            }

            context.Phones.Update(phone);
            context.SaveChanges();

            TempData[WebConstants.alertMsgKey] = "Phone was edited successfully!";

            return RedirectToAction(nameof(Manage));
        }

        // GET: /Phones/Delete/{id}
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var phone = context.Phones.Find(id);

            if (phone == null) return NotFound();

            context.Phones.Remove(phone);
            context.SaveChanges();

            TempData[WebConstants.alertMsgKey] = "Phone was deleted successfully!";

            return RedirectToAction(nameof(Manage));
        }
    }
}
