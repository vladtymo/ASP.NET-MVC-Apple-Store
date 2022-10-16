using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MVC_apple_store.Helpers;
using MVC_apple_store.Services;

namespace MVC_apple_store.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly StoreDbContext context;

        public CartController(ICartService cartService, StoreDbContext context)
        {
            this.cartService = cartService;
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = cartService.GetProductsFromCart();

            return View(products);
        }

        public IActionResult Add(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = context.Phones.Find(productId);

            if (phone == null) return NotFound();

            cartService.AddProductToCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }
        public IActionResult Remove(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = context.Phones.Find(productId);

            if (phone == null) return NotFound();

            cartService.RemoveProductFromCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }
    }
}
