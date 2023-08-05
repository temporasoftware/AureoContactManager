using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.AppServices;

namespace WebApp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly IContactsService _service;

        public EditModel(IContactsService theService)
        {
            _service = theService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public DbModels.Contacts Contact { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _service.AddNew(Contact))
                return RedirectToPage("./Index");
            else
                return Page();
        }
    }
}