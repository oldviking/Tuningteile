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
    public class IndexModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public IndexModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public IList<TuningPart> TuningPart { get;set; }

        //list all items
        public async Task<RedirectToPageResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login", true);
            }

            TuningPart = await _context.TuningPart.ToListAsync();
            return null;
        }
    }
}
