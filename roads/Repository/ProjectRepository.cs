using Microsoft.EntityFrameworkCore;
using roads.Data;
using roads.Interfaces;
using roads.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace roads.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _appDbContext.Projects.ToListAsync();
        }
        public async Task<IEnumerable<Project>> GetAllComplete()
        {
            return await _appDbContext.Projects
                 .Include(p => p.ProjectStatus)
                 .ToListAsync();
        }
        public async Task<Project> GetByIdAsync(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return await _appDbContext.Projects
               .Include(p => p.ProjectStatus)
               .Include(p => p.Tasks)
               .FirstOrDefaultAsync(project => project.Id == id);
        }
    }
}
