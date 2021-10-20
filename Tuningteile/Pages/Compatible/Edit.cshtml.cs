using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuningteile.Data;
using Tuningteile.Models;

namespace Tuningteile.Pages.Compatible
{
    public class EditModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public EditModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public compatibility compatibility { get; set; }

        //edit an item
        public async Task<IActionResult> OnGetAsync(int? TuningPartId, int? ModelId)
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }
            if (TuningPartId == null)
            {
                return NotFound();
            }

            compatibility = await _context.compatibility
                .Include(c => c.Model)
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.TuningPart).FirstOrDefaultAsync(m => (m.TuningPartId == TuningPartId) && (m.ModelID == ModelId));

            if (compatibility == null)
            {
                return NotFound();
            }
           ViewData["ModelID"] = new SelectList(_context.Models, "Id", "Name");
           ViewData["TuningPartId"] = new SelectList(_context.TuningPart, "Id", "Name");
            return Page();
        }


        //save the edited item to the database
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(compatibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!compatibilityExists(compatibility.TuningPartId))
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

        private bool compatibilityExists(int id)
        {
            return _context.compatibility.Any(e => e.TuningPartId == id);
        }
    }
}
