using roads.Models;

namespace roads.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<IEnumerable<Project>> GetAllComplete();

        Task<Project> GetByIdAsync(int id);
    }
}
