using WebApp.DbModels;
using WebApp.DbModels.Dto;

namespace WebApp.AppServices
{
    public interface IContactsService
    {

        Task<bool> AddNew(Contacts contact);
        Task<bool> Save(Contacts contact);
        Task<List<Contacts>> GetAll();
        Task<PagedTableReturnDto<Contacts>> GetPaged(int page);
        Task<Contacts> Get(string recordId);
        Task<bool> Delete(string recordId);
        public string Error { get; set; }

    }
}
