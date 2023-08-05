using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.AppServices;

namespace WebApp.Pages.Contacts
{
    public class IndexModel : PageModel
    {

        private readonly IContactsService _service;

        public IndexModel(IContactsService theService)
        {
            _service = theService;
        }
        public IList<DbModels.Contacts> Contacts { get; set; }

        public async Task OnGetAsync()
        {
            Contacts = await _service.GetAll();
        }
    }
}
