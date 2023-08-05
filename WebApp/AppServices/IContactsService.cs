using WebApp.DbModels;

namespace WebApp.AppServices
{
    public interface IContactsService
    {

        Task<bool> AddNew(Contacts contact);
        Task<List<Contacts>> GetAll();

    }
}
