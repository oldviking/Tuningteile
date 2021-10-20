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
    public class CreateModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public CreateModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // if user is not loged in, redirect him to the login form
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }

            //fill dropdowns(selects)
            ViewData["ModelID"] = _context.Models
                    .Include(x => x.Manufacturer)
                    .Select(y => new SelectListItem
                    {
                        Value = y.Id.ToString(),
                        Text = y.Name
                    }).ToList();

            ViewData["TuningPartId"] = _context.TuningPart
                .Select(y => new SelectListItem
                {
                    Value = y.Id.ToString(),
                    Text = y.Name
                }).ToList();
            return Page();
        }

        [BindProperty]
        public compatibility compatibility { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.compatibility.Add(compatibility);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
