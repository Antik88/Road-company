namespace roads.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAll();
        Task<Task> GetByIdAsync(int id);
        bool Add(Task task);
        bool Update(Task task);
        bool Delete(Task task);
        bool Save();
    }
}
