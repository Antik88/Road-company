using roads.Models;

namespace roads.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<IEnumerable<Project>> GetAllComplete();
        Task<Project> GetByIdAsyncNoTracing(int id);
        Task<Project> GetByIdAsync(int id);
        Task<Models.Task> GetTaskById(int id); 
        bool AddTask(Models.Task task);
        bool AddExpense(Expense expense);
        bool AddSub(Subcontractor sub);
        bool AddMaterial(Material material);
        bool Add(Project project);
        bool Update(Project project);
        bool UpdateTask(Models.Task task);
        bool Delete(Project project);
        bool Save();
    }
}
