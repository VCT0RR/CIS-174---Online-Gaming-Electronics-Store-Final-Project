using FinalProjectRyan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectRyan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private CartContext cartContext;
        private List<Category> categories;

        public ProductsController(CartContext cartCtx)
        {
            this.cartContext = cartCtx;
            categories = cartContext.Categories.OrderBy(c => c.CategoryID).ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Products> products;
            if (id == "All")
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

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Add()
        {
            Products products = new Products();

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            return View("Update", products);
        }

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Update(int id)
        {
            Products products = cartContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductID == id) ?? new Products();

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("Update", products);
        }

        [HttpPost]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Update(Products products)
        {
            if (ModelState.IsValid)
            {
                if (products.ProductID == 0)
                {
                    cartContext.Products.Add(products);
                }
                else 
                {
                    cartContext.Products.Update(products);
                }
                cartContext.SaveChanges();
                TempData["message"] = products.ProductModel + " saved";

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;

                return View("Update", products);
            }
        }

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Delete(int id)
        {
            Products products = cartContext.Products.FirstOrDefault(p => p.ProductID == id) ?? new Products();

            return View(products);
        }

        [HttpPost]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Delete(Products products)
        {
            cartContext.Products.Remove(products);
            cartContext.SaveChanges();

            TempData["message"] = products.ProductModel + " deleted";

            return RedirectToAction("List");
        }
    }
}
