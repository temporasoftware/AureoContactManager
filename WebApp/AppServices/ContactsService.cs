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

        public async Task<bool> AddNew(Contacts contact)
        {
            Context.Contacts.Add(contact);

            if (await Context.SaveChangesAsync() > 0)
                return true;
            else 
                return false;
        }
    }
}
