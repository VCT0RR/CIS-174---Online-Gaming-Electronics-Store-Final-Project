using Microsoft.AspNetCore.Mvc;

namespace FinalProjectRyan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult ContactUs()
        {
            var contactInfo = new Dictionary<string, string> {
                { "Phone Number", "515-334-2255" },
                { "Email Address", "gamingstore@gmail.com" }
            };
            return View(contactInfo);
        }
    }
}
