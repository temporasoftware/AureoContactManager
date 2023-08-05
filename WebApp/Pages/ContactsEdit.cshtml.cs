using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.AppServices;
using WebApp.DbModels;

namespace WebApp.Pages
{
    public class ContactsEditModel : PageModel
    {

        private readonly IContactsService _service;

        public ContactsEditModel(IContactsService theService)
        {
            _service = theService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Contacts Contact { get; set; }


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