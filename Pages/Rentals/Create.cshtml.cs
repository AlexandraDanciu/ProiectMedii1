using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public CreateModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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

        [BindProperty]
        public Rental Rental { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
