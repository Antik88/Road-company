namespace roads.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Task> GetTasById(int id);
        bool DeleteTask(Models.Task task);
        bool Save();
    }
}
