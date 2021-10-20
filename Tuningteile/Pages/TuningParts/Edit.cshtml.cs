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

namespace Tuningteile.Pages.TuningParts
{
    public class EditModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public EditModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TuningPart TuningPart { get; set; }
        //get the to edit item
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

        //save the item to the db
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TuningPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuningPartExists(TuningPart.Id))
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

        private bool TuningPartExists(int id)
        {
            return _context.TuningPart.Any(e => e.Id == id);
        }
    }
}
