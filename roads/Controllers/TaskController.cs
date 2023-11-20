using Microsoft.AspNetCore.Mvc;
using roads.Interfaces;

namespace roads.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskRepository.GetTasById(id);
            if (task == null) return View("Error");

            _taskRepository.DeleteTask(task);
            return RedirectToAction(actionName: "Index", controllerName: "Project");
        }
    }
}
