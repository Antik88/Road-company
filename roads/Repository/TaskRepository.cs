using roads.Data;
using roads.Interfaces;

namespace roads.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Models.Task> GetTasById(int id)
        {
            return await _appDbContext.Tasks.FindAsync(id);
        }
        public bool DeleteTask(Models.Task task)
        {
            _appDbContext.Tasks.Remove(task);
            return Save();
        }
        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0;
        }
    }
}
