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
    public class DeleteModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public DeleteModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TuningPart TuningPart { get; set; }

        //delete item from db
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

            TuningPart = await _context.TuningPart.FirstOrDefaultAsync(m => m.Id == id);

            if (TuningPart == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TuningPart = await _context.TuningPart.FindAsync(id);

            if (TuningPart != null)
            {
                _context.TuningPart.Remove(TuningPart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
