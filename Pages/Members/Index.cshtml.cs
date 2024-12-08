using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Data;
using ProiectMedii1.Models;

namespace ProiectMedii1.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii1.Data.ProiectMedii1Context _context;

        public IndexModel(ProiectMedii1.Data.ProiectMedii1Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
