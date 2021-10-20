using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tuningteile.Data;
using Tuningteile.Models;

namespace Tuningteile.Pages.Compatible
{
    public class DetailsModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public DetailsModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public compatibility compatibility { get; set; }

        //show details from a item
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
            return Page();
        }
    }
}
