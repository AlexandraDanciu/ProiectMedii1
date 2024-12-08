using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public IndexModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get; set; } = default!;
        public EquipmentData EquipmentD { get; set; }
        public int EquipmentID { get; set; }
        public int CategoryID { get; set; }
        public string NameSort { get; set; }
        public string CategoryNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CategoryNameSort = sortOrder == "category" ? "category_desc" : "category";
            CurrentFilter = searchString;
            EquipmentD = new EquipmentData();
            EquipmentD.Equipments = await _context.Equipment
                .Include(b => b.EquipmentCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                EquipmentD.Equipments = EquipmentD.Equipments.Where(s => s.Name.Contains(searchString) || s.EquipmentCategories.Any(ec => ec.Category.CategoryName.Contains(searchString)));
            }
            if (id != null)
            {
                EquipmentID = id.Value;
                Equipment equipment = EquipmentD.Equipments
                    .Where(i => i.ID == id.Value).Single();
                EquipmentD.Categories = equipment.EquipmentCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    EquipmentD.Equipments = EquipmentD.Equipments.OrderByDescending(s => s.Name);
                    break;
                case "category":
                    EquipmentD.Equipments = EquipmentD.Equipments.OrderBy(e => e.EquipmentCategories.FirstOrDefault().Category.CategoryName);
                    break;
                case "category_desc":
                    EquipmentD.Equipments = EquipmentD.Equipments.OrderByDescending(e => e.EquipmentCategories.FirstOrDefault().Category.CategoryName);
                    break;
                default:
                    EquipmentD.Equipments = EquipmentD.Equipments.OrderBy(e => e.Name);
                    break;
            }
        }
    }
}
