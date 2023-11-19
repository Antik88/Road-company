using Microsoft.EntityFrameworkCore;
using roads.Models;

namespace roads.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<OrderMaterial> OrderMaterials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<Subcontractor> Subcontractors { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }
}
