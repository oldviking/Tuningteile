using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tuningteile.Data;
using Tuningteile.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Tuningteile.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly Tuningteile.Data.TuningteileContext _context;

        public LoginModel(Tuningteile.Data.TuningteileContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        //public User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
           
            return Page();
        }
        /// <summary>
        /// Login method
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            string input_hash = null;
            User user = _context.Users.FirstOrDefault(us => us.Username == username);
            if (user != null)
            {
                //get password hash
                input_hash = PassWordFunctions.GetHasch(password, PassWordFunctions.GetByteArrayFomString(user.salt));
                if (PassWordFunctions.VerifyHash(user.Password, input_hash))
                {
                    //cookie auth 
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("Fullname", user.Firstname + user.Lastname),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {

                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToPage("/Index", true);
                }
                else
                {
                    return RedirectToPage("./wrong_cred");
                }
            }
            else
            {
                return RedirectToPage("./wrong_cred");
            }
            return null;
        }
    }
}
