using Microsoft.EntityFrameworkCore;
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

        public Task<List<Contacts>> GetAll()
        {
            return Context.Contacts.AsNoTracking().ToListAsync();
        }

        public Task<Contacts> Get(string recordId)
        {
            return Context.Contacts.AsNoTracking().Where(a => a.Id == recordId).FirstOrDefaultAsync();  
        }
    }
}
