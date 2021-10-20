using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tuningteile.Data;
using Tuningteile.Models;

namespace Tuningteile.Pages.TuningParts
{
    public class CreateModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public CreateModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //see create from compatibility
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }
            //fill category dropdown
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public TuningPart TuningPart { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TuningPart.Add(TuningPart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
