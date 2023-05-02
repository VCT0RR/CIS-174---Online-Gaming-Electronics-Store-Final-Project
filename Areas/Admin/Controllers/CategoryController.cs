using FinalProjectRyan.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectRyan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CartContext cartContext;
        public CategoryController(CartContext cartCtx)
        {
            this.cartContext = cartCtx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //[Route("[area]/Categories/{id?}")]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult List()
        {
            var categories = cartContext.Categories.OrderBy(c => c.CategoryID).ToList();
            return View(categories);
        }

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Update", new Category());
        }

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = this.cartContext.Categories.Find(id);

            return View("Update", category);
        }

        [HttpPost]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryID == 0)
                {
                    this.cartContext.Categories.Add(category);
                }
                else
                {
                    this.cartContext.Categories.Update(category);
                }
                this.cartContext.SaveChanges();
                TempData["message"] = category.CategoryName + " saved";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("Update");
            }
        }

        [HttpGet]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Delete(int id)
        {
            Category category = this.cartContext.Categories.Find(id) ?? new Category();
            return View(category);
        }


        [HttpPost]
        [Route("[area]/[controller]s/[action]/{id?}")]
        public IActionResult Delete(Category category)
        {
            this.cartContext.Categories.Remove(category);
            this.cartContext.SaveChanges();
            TempData["message"] = category.CategoryName + " deleted";
            return RedirectToAction("List");
        }
    }
}
