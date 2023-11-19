using Microsoft.AspNetCore.Mvc;

namespace roads.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProject()
        {
            return View();
        }
        public IActionResult MaterialList()
        {
            return View();
        }
        public IActionResult OrderMaterial()
        {
            return View();
        }
    }
}
