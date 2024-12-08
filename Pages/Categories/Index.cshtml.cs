using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;
using ProiectMedii1.Models.ViewModels;

namespace ProiectMedii1.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public IndexModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;


        public CategoryEquipmentData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            // Inițializăm ViewModel-ul cu categoriile
            CategoryData = new CategoryEquipmentData();
            CategoryData.Categories = await _context.Category
                     .Include(i => i.EquipmentCategories) // Include tabela intermediară
                         .ThenInclude(c => c.Equipment) // Include echipamentele din relația intermediară
                     .OrderBy(i => i.CategoryName)
                     .ToListAsync();

            // Dacă o categorie este selectată
            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .SingleOrDefault();

                if (category != null)
                {
                    // Extrage echipamentele asociate categoriei
                    CategoryData.Equipments = category.EquipmentCategories
                        .Select(ec => ec.Equipment)
                        .ToList();
                }
            }

        }
    }
}
