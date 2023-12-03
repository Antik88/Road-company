using Microsoft.AspNetCore.Mvc;
using roads.Interfaces;
using roads.Models;
using roads.ViewModels;

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

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            var projectStatus = new ProjectStatus
            {
                Status = "Initial",
                Date = DateTime.Now
            };

            project.ProjectStatus = projectStatus;

            _projectRepository.Add(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            var projectVm = new ProjectViewModel
            {
                Id = id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                RoadAddress = project.RoadAddress,
                startPointLat = project.startPointLat,
                endPointLat = project.endPointLat,
                startPointLng = project.startPointLng,
                endPointLng = project.endPointLng,
                ProjectStatusId = project.ProjectStatusId,
                ProjectStatus = project.ProjectStatus,
            };

            return View(projectVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProjectViewModel projectVm)
        {
            var project = new Project
            {
                Id = id,
                ProjectName = projectVm.ProjectName,
                Description = projectVm.Description,
                StartDate = projectVm.StartDate,
                EndDate = projectVm.EndDate,
                RoadAddress = projectVm.RoadAddress,
                startPointLat = projectVm.startPointLat,
                endPointLat = projectVm.endPointLat,
                startPointLng = projectVm.startPointLng,
                endPointLng = projectVm.endPointLng,
                ProjectStatusId = projectVm.ProjectStatusId,
                ProjectStatus = projectVm.ProjectStatus,
            };

            _projectRepository.Update(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddTask(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            var task = new TaskViewModel
            {
                ProjectId = id,
                ProjectName = project.ProjectName,
            };

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskViewModel taskVm)
        {
            var task = new Models.Task
            {
                ProjectId = taskVm.ProjectId,
                Description = taskVm.Description,
                Status = taskVm.Status,
            };

            _projectRepository.AddTask(task);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddExp(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            var exp = new ExpViewModel
            {
                ProjectId = id,
                ProjectName = project.ProjectName,
            };

            return View(exp);
        }

        [HttpPost]
        public async Task<IActionResult> AddExp(ExpViewModel expVm)
        {
            var expense = new Models.Expense
            {
                ProjectId = expVm.ProjectId,
                Description = expVm.Description,
                Amount = expVm.Amount,
                ExpenseDate = expVm.ExpenseDate,
            };

            _projectRepository.AddExpense(expense);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SubProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            var sub = new SubcontractorViewModel
            {
                ProjectId = id,
                ProjectName = project.ProjectName
            };

            return View(sub);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubProject(SubcontractorViewModel subVm)
        {
            var sub = new Subcontractor
            {
                ProjectId = subVm.ProjectId,
                Name = subVm.Name,
                ContactPerson = subVm.ContactPerson,
                ContactInfo = subVm.ContactInfo,
            };

            _projectRepository.AddSub(sub);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MaterialProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            var material = new MaterialViewModel 
            {
                ProjectId = id,
                ProjectName = project.ProjectName
            };

            return View(material);
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterialProject(MaterialViewModel materialVm)
        {
            var project = await _projectRepository.GetByIdAsync(materialVm.ProjectId);
            if (project == null) return View("Error");

            var material = new Material 
            {
                Project = project,
                Name = materialVm.Name,
                UnitOfMeasurement = materialVm.UnitOfMeasurement,
                Quantity = materialVm.Quantity 
            };

            _projectRepository.AddMaterial(material);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditTask(int id)
        {
            var task = await _projectRepository.GetTaskById(id);
            if (task == null) return View("Error");

            var project = await _projectRepository.GetByIdAsync(task.ProjectId);

            var taskVm = new TaskViewModel
            {
                Id = id,
                ProjectId = project.Id,
                Description = task.Description,
                Status = task.Status,
                Project = project 
            };

            return View(taskVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(TaskViewModel taskVm)
        {
            var task = new Models.Task 
            {
                Description = taskVm.Description,
                Status = taskVm.Status,
                Id = taskVm.Id,
                ProjectId = taskVm.ProjectId,
            };

            _projectRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return View("Error");

            _projectRepository.Delete(project);
            return RedirectToAction("Index");
        }
    }
}
