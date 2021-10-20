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
    public class indexModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public indexModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public IList<compatibility> compatibility { get;set; }

        //list all items
        public async Task<RedirectToPageResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }
            compatibility = await _context.compatibility
                .Include(c => c.Model)
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.TuningPart).ToListAsync();

            return null;
        }
    }
}
