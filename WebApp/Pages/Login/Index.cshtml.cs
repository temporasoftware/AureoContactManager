using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApp.DbModels.Dto;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Pages.Login
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public UserAuthenticationLoginDto Login { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Login.UserName == "alfa@soft.com" && Login.Password == "alfa")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Login.UserName),
                    // Adicione outros claims conforme necessário
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                    IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                return LocalRedirect(Url.Content("~/"));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect email or password. Please try again.");
                return Page();

            }
        }

    }
}
