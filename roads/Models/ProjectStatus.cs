using System.Text.Json.Serialization;

namespace roads.Models
{
    public class ProjectStatus
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public List<Project> Projects { get; set; }
    }
}
