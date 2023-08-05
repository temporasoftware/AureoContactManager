using WebApp.DbInfra;
using WebApp.DbModels;

namespace WebApp.AppServices
{
    public class ContactsService : IContactsService
    {

        public AppDbContext Context { get; set; }


        public ContactsService(AppDbContext theContext)
        {
            Context = theContext;
        }


        public Task<bool> AddNew()
        {
            throw new NotImplementedException();
        }
    }
}
