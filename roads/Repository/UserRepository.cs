using Microsoft.EntityFrameworkCore;
using roads.Data;
using roads.Interfaces;
using roads.Models;
using System.Collections.Immutable;

namespace roads.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Add(User user)
        {
            _appDbContext.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _appDbContext.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return await _appDbContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetUserByLogin(string login)
        {
            return await _appDbContext.User.Where(user => user.Login.Contains(login)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> CheckCredentials(string login, string password)
        {
            return await _appDbContext.User
                .FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
        }
    }
}
