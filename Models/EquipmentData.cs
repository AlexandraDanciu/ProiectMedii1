namespace ProiectMedii1.Models
{
    public class EquipmentData
    {
        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EquipmentCategory> EquipmentCategories { get; set; }
    }
}
