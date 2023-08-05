using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.AppServices;
using static WebApp.Helpers.EditPageHelpers;

namespace WebApp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly IContactsService _service;

        public EditModel(IContactsService theService)
        {
            _service = theService;
        }

        public async Task<IActionResult> OnGetAsync(string id, bool edit)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Contact = await _service.Get(id);
                if(edit)
                    EditMode = EditPageMode.Edit;
                else
                    EditMode = EditPageMode.View;

            }
            else
            {
                Contact = new DbModels.Contacts();
                Contact.Id = "new_record";
                EditMode = EditPageMode.AddNew;
            }

            if (Contact == null)
                return RedirectToPage("./Index");

            return Page();
        }

        [BindProperty]
        public DbModels.Contacts Contact { get; set; }

        public EditPageMode EditMode { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if(Contact.Id == "new_record")
            {
                if (await _service.AddNew(Contact))
                    return RedirectToPage("./Index");
                else
                {
                    ModelState.AddModelError("", _service.Error);
                    return Page();
                }
            }

            return Page();
        }
    }
}