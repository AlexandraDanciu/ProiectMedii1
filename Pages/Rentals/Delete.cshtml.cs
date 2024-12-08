using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Rentals
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public DeleteModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
       .Include(r => r.Equipment) 
       .Include(r => r.Member)   
       .FirstOrDefaultAsync(m => m.ID == id);
            if (rental == null)
            {
                return NotFound();
            }
            else
            {
                Rental = rental;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);

            if (rental != null)
            {
                Rental = rental;
                _context.Rental.Remove(Rental);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
