using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Equipments
{
    public class EditModel : EquipmentCategoriesPageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public EditModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipment
                .Include(b => b.EquipmentCategories)
                    .ThenInclude(b => b.Category).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Equipment);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            { 
                return NotFound();
            }

            var equipmentToUpdate = await _context.Equipment
                .Include(i => i.EquipmentCategories)
                    .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            
            if (equipmentToUpdate == null) 
            { 
                return NotFound(); 
            }

            if (await TryUpdateModelAsync<Equipment>(
                equipmentToUpdate,
                "Equipment",
                i => i.Name,
                i => i.Price, 
                i => i.Piecies, //pieces
                i => i.Availability))
            {
                UpdateEquipmentCategories(_context, selectedCategories, equipmentToUpdate); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index");
            }

            UpdateEquipmentCategories(_context, selectedCategories, equipmentToUpdate);
            PopulateAssignedCategoryData(_context, equipmentToUpdate); 
            return Page();
        }
    }
}