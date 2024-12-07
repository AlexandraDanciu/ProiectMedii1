using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMedii1.Data;

namespace ProiectMedii1.Models
{
    public class EquipmentCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList; 
        public void PopulateAssignedCategoryData(ProiectMedii1Context context, Equipment equipment)
        {
            var allCategories = context.Category;
            var equipmentCategories = new HashSet<int>(equipment.EquipmentCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();       
            foreach (var cat in allCategories)           
            {            
                AssignedCategoryDataList.Add(new AssignedCategoryData          
                {                     
                    CategoryID = cat.ID,     
                    Category_name = cat.CategoryName,       
                    Assigned = equipmentCategories.Contains(cat.ID)              
                });       
            }          
        }     
        public void UpdateEquipmentCategories(ProiectMedii1Context context,    
            string[] selectedCategories, Equipment equipmentToUpdate)           
        {            
            if (selectedCategories == null)    
            {                    
                equipmentToUpdate.EquipmentCategories= new List<EquipmentCategory>();                
                return;       
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories); 
            var equipmentCategories = new HashSet<int>(equipmentToUpdate.EquipmentCategories.Select(c => c.Category.ID));
            
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString())) 
                { 
                    if (!equipmentCategories.Contains(cat.ID)) 
                    { 
                        equipmentToUpdate.EquipmentCategories.Add(new EquipmentCategory 
                        { 
                            EquipmentID = equipmentToUpdate.ID, 
                            CategoryID = cat.ID
                        });
                    }
                } else{ 
                    if (equipmentCategories.Contains(cat.ID)) 
                    {
                        EquipmentCategory equipmentToRemove = equipmentToUpdate
                            .EquipmentCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID); 
                        context.Remove(equipmentToRemove);
                    } 
                } 
            }
        }
    }
}
