namespace roads.Models
{
    public class Subcontractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string ContactInfo { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
