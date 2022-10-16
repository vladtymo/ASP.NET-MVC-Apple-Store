using Microsoft.AspNetCore.Mvc;

namespace MVC_apple_store.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Add()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
