using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Experiences
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public DetailsModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public Experience Experience { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.Include(e => e.Member).FirstOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }
            else
            {
                Experience = experience;
            }
            return Page();
        }
    }
}
