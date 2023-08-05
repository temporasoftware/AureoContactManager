using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.AppServices;
using WebApp.DbModels.Dto;

namespace WebApp.Pages.Contacts
{
    public class IndexModel : PageModel
    {

        private readonly IContactsService _service;

        public IndexModel(IContactsService theService)
        {
            _service = theService;
        }
        public PagedTableReturnDto<DbModels.Contacts> ContactsPage { get; set; }

        public async Task OnGetAsync(int id)
        {
            ContactsPage = await _service.GetPaged(id);

        }
    }
}
