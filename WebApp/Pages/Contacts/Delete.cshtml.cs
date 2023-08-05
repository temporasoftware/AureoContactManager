using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.AppServices;

namespace WebApp.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly IContactsService _service;

        public DeleteModel(IContactsService theService)
        {
            _service = theService;
        }

        public async Task<IActionResult> OnGetAsync(string id, bool edit, bool delete)
        {
            await _service.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
