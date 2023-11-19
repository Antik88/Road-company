using System.Text.Json.Serialization;

namespace roads.Models
{
    public class Project
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

        [JsonIgnore]
        public List<Task> Tasks { get; set; }
        [JsonIgnore]
        public List<Expense> Expenses { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        [JsonIgnore]
        public List<Subcontractor> Subcontractors { get; set; }

        [JsonIgnore]
        public List<Material> Materials { get; set; }
    }
}
