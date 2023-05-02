using Microsoft.AspNetCore.Mvc;

namespace FinalProjectRyan.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(string id)
        {
            TempData["message"] = id + " added to your cart";
            return RedirectToAction("ListView", "Products");
        }
    }
}
