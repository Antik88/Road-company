using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using roads.Data;
using roads.Interfaces;
using roads.Models;
using roads.ViewModels;
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

        public bool Add(Project project)
        {
            _appDbContext.Projects.Add(project);
            return Save();
        }

        public bool Delete(Project project)
        {
            _appDbContext.Remove(project);
            return Save();
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
        public async Task<Project> GetByIdAsyncNoTracing(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return await _appDbContext.Projects
               .Include(p => p.ProjectStatus)
               .Include(p => p.Tasks)
               .AsNoTracking()
               .FirstOrDefaultAsync(project => project.Id == id);
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
               .Include(p => p.Expenses)
               .Include(p => p.Subcontractors)
               .Include(p => p.Materials)
               .FirstOrDefaultAsync(project => project.Id == id);
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0;
        }

        public bool Update(Project project)
        {
            _appDbContext.Update(project);
            return Save();
        }

        public bool AddTask(Models.Task task)
        {
            _appDbContext.Tasks.Add(task);
            return Save();
        }

        public bool AddExpense(Expense expense)
        {
            _appDbContext.Expenses.Add(expense);
            return Save();
        }

        public bool AddSub(Subcontractor sub)
        {
            _appDbContext.Subcontractors.Add(sub);
            return Save();
        }
        public bool AddMaterial(Material material)
        {
            _appDbContext.Materials.Add(material);
            _appDbContext.SaveChanges();

            int id = material.Id;

            var orderMaterial = new OrderMaterial
            {
                MaterialId = id,
                QuantityOrdered = material.Quantity,
                UnitOfMeasurement = material.UnitOfMeasurement,
                OrderDate = DateTime.Now
            };

            _appDbContext.OrderMaterials.Add(orderMaterial);

            return Save();
        }
        public bool UpdateTask(Models.Task task)
        {
            _appDbContext.Tasks.Update(task);
            return Save();
        }
        public async Task<Models.Task> GetTaskById(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return await _appDbContext.Tasks
               .FirstOrDefaultAsync(task => task.Id == id);
        }
    }
}
