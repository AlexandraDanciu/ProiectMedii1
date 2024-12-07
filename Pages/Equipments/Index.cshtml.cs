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
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            EquipmentD = new EquipmentData();
            EquipmentD.Equipments = await _context.Equipment
                .Include(b => b.EquipmentCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (id != null)
            {
                EquipmentID = id.Value;
                Equipment equipment = EquipmentD.Equipments
                    .Where(i => i.ID == id.Value).Single();
                EquipmentD.Categories = equipment.EquipmentCategories.Select(s => s.Category);
            }
        }
    }
}
