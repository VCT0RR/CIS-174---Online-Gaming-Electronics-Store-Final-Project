using FinalProjectRyan.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectRyan.Controllers
{
    public class ProductsController : Controller
    {
        private CartContext cartContext;

        public IActionResult Index()
        {
            return RedirectToAction("ListView");
        }

        public ProductsController(CartContext cartCtx)
        {
            this.cartContext = cartCtx;
        }

        [Route("[controller]s/{id?}")]
        public IActionResult ListView(string id = "All")
        {
            var categories = this.cartContext.Categories.OrderBy(c => c.CategoryID).ToList();

            List<Products> products;

            if(id == "All")
            {
                products = cartContext.Products.OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = cartContext.Products.Where(p => p.Category.CategoryName == id).OrderBy(p => p.ProductID).ToList();
            }

            var model = new ProductViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };

            return View(model);
        }

        public IActionResult DetailsView(int id)
        {
            var categories = cartContext.Categories.OrderBy(c => c.CategoryID).ToList();

            Products products = cartContext.Products.Find(id) ?? new Products();

            ViewBag.Categories = categories;
            return View(products);
        }
    }
}
