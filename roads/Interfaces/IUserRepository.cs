using roads.Models;

namespace roads.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetUserByLogin(string login);
        Task<User> CheckCredentials(string login, string password);
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
