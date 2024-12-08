namespace ProiectMedii1.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<EquipmentCategory>? EquipmentCategories { get; set; } = new List<EquipmentCategory>();
    }
}
