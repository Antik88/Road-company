using Microsoft.AspNetCore.Mvc;
using roads.Interfaces;
using roads.Models;

namespace roads.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectRepository.GetAllComplete();
            return View(projects);
        }

        public async Task<IActionResult> Details(int id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            return View(project);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
