using System.ComponentModel.DataAnnotations;

namespace roads.Models
{
    public class OrderMaterial
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int QuantityOrdered { get; set; }
        public string UnitOfMeasurement { get; set; }
        public DateTime OrderDate { get; set; }
        public Material Material { get; set; }
    }
}
