using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tuningteile.Data;
using Tuningteile.Models;

namespace Tuningteile.Pages.Auth
{
    public class AddLoginModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public AddLoginModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return RedirectToPage("/Auth/login");
            }
            return Page();
        }

        [BindProperty]
        public User user { get; set; }


        /// <summary>
        /// When the fuction is run, it adds a user to the database
        /// </summary>
        /// <returns></returns>
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            byte[] salt = PassWordFunctions.GetSalt();
            user.salt = PassWordFunctions.GetStringfromByteArray(salt);
            user.Password = PassWordFunctions.GetHasch(Password: user.Password, salt: salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
