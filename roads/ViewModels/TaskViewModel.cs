using roads.Models;

namespace roads.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public Project Project { get; set; }
    }
}
