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

namespace ProiectMedii1.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public EditModel(ProiectMedii1.Data.ProiectMedii1Context context)
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
            var equipmentList = _context.Equipment
      .Select(e => new
      {
          e.ID,
          EquipmentName = e.Name
      }).ToList();

            var memberList = _context.Member
                .Select(m => new
                {
                    m.ID,
                    FullName = m.FirstName + " " + m.LastName // Numele complet al membrului
                }).ToList();

            ViewData["EquipmentID"] = new SelectList(equipmentList, "ID", "EquipmentName");
            ViewData["MemberID"] = new SelectList(memberList, "ID", "FullName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(Rental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentalExists(int id)
        {
            return _context.Rental.Any(e => e.ID == id);
        }
    }
}
