using Microsoft.AspNetCore.Mvc;
using roads.Interfaces;
using roads.Models;
using System.Diagnostics;

namespace roads.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> users = await _projectRepository.GetAll(); 
            return View(users);
        }

        public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}