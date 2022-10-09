using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MVC_apple_store.Helpers;

namespace MVC_apple_store.Controllers
{
    public class CartController : Controller
    {
        private readonly StoreDbContext context;

        public CartController(StoreDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = GetProductsFromCart();

            return View(products);
        }

        public IActionResult Add(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = context.Phones.Find(productId);

            if (phone == null) return NotFound();

            AddProductToCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }
        public IActionResult Remove(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = context.Phones.Find(productId);

            if (phone == null) return NotFound();

            RemoveProductFromCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }

        private void AddProductToCart(int id)
        {
            var productIds = HttpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);
            
            if (productIds == null)
                productIds = new List<int>();

            productIds.Add(id);

            HttpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        private void RemoveProductFromCart(int id)
        {
            var productIds = HttpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return;

            productIds.Remove(id);

            HttpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        private IEnumerable<Phone?> GetProductsFromCart()
        {
            var productIds = HttpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return new List<Phone?>();

            List<Phone?> phones = productIds.Select(id => context.Phones.Find(id)).ToList();

            return phones;
        }
    }
}
