using roads.Models;

namespace roads.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoadAddress { get; set; }
        public double startPointLat { get; set; }
        public double startPointLng { get; set; }
        public double endPointLat { get; set; }
        public double endPointLng { get; set; }
        public int ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public List<Models.Task> Tasks { get; set; }
    }
}
