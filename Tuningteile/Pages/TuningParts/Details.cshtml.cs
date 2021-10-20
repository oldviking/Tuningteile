using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tuningteile.Data;
using Tuningteile.Models;

namespace Tuningteile.Pages.TuningParts
{
    public class DetailsModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public DetailsModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public TuningPart TuningPart { get; set; }

        //show details 
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }
            if (id == null)
            {
                return NotFound();
            }

            TuningPart = await _context.TuningPart.Include(x => x.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            

            if (TuningPart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
