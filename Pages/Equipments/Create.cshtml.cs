using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Equipments
{
    public class CreateModel : EquipmentCategoriesPageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public CreateModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var equipment = new Equipment();
            equipment.EquipmentCategories = new List<EquipmentCategory>();
            PopulateAssignedCategoryData(_context, equipment);
            return Page();
        }

        [BindProperty]
        public Equipment Equipment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newEquipment = new Equipment(); 
            if (selectedCategories != null) 
            {
                newEquipment.EquipmentCategories = new List<EquipmentCategory>(); 
                foreach (var cat in selectedCategories)
                { 
                    var catToAdd = new EquipmentCategory
                    { 
                        CategoryID = int.Parse(cat) 
                    };
                    newEquipment.EquipmentCategories.Add(catToAdd);
                }
            }

            Equipment.EquipmentCategories = newEquipment.EquipmentCategories;
            _context.Equipment.Add(Equipment);

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
