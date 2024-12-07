namespace ProiectMedii1.Models
{
    public class EquipmentCategory
    {
        public int ID { get; set; }
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
