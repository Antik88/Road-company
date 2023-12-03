namespace roads.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Quantity { get; set; }
        public int ProjectId {  get; set; }
        public Project Project { get; set; }
        public List<OrderMaterial> OrderMaterials { get; set; }
    }
}
