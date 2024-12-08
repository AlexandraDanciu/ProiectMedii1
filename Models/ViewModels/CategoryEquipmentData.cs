using ProiectMedii1.Models;
namespace ProiectMedii1.Models.ViewModels
{
    public class CategoryEquipmentData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
    }
}
