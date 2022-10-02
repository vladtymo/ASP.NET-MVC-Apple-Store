﻿using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_apple_store.Models;
using MVC_apple_store.ViewModels;

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
            CreatePhoneViewModel viewModel = new CreatePhoneViewModel()
            {
                Colors = new SelectList(context.Colors, nameof(Color.Id), nameof(Color.Name))
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            if (!ModelState.IsValid) return View();

            context.Phones.Add(phone);
            context.SaveChanges();

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
