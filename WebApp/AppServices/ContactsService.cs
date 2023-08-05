using Microsoft.EntityFrameworkCore;
using WebApp.DbInfra;
using WebApp.DbModels;
using WebApp.DbModels.Dto;

namespace WebApp.AppServices
{
    public class ContactsService : IContactsService
    {

        public AppDbContext Context { get; set; }

        public string Error { get; set; }

        public ContactsService(AppDbContext theContext)
        {
            Context = theContext;
        }

        public async Task<bool> Save(Contacts contact)
        {
            var currentRecord = await Context.Contacts.FirstOrDefaultAsync(c => c.Id == contact.Id);

            if (currentRecord == null)
            {
                Error = "Record not found";
                return false;
            }

            if (Context.Contacts.Where(a => a.Email == contact.Email && a.Id != contact.Id).Any())
            {
                Error = "There is already a record with this email";
                return false;
            }

            if (Context.Contacts.Where(a => a.Contact == contact.Contact && a.Id != contact.Id).Any())
            {
                Error = "There is already a record with this contact information";
                return false;
            }

            currentRecord.Email = contact.Email;
            currentRecord.Contact = contact.Contact;
            currentRecord.Name = contact.Name;

            if (await Context.SaveChangesAsync() > 0)
                return true;
            else
            {
                Error = "Error saving record";
                return false;
            }
                
        }

        public async Task<bool> AddNew(Contacts contact)
        {
            if(Context.Contacts.Where(a => a.Email == contact.Email).Any())
            {
                Error = "There is already a record with this email";
                return false;
            }

            if (Context.Contacts.Where(a => a.Contact == contact.Contact).Any())
            {
                Error = "There is already a record with this contact information";
                return false;
            }

            var newRecord = new Contacts()
            {
                Email = contact.Email,
                Contact = contact.Contact,
                Audit_RecordStatus = false,
                Name = contact.Name
            };

            Context.Contacts.Add(contact);

            if (await Context.SaveChangesAsync() > 0)
                return true;
            else
            {
                Error = "Error saving record";
                return false;
            }
        }

        public async Task<List<Contacts>> GetAll()
        {
            return await Context.Contacts.AsNoTracking().OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<Contacts> Get(string recordId)
        {
            return await Context.Contacts.AsNoTracking().Where(a => a.Id == recordId).FirstOrDefaultAsync();  
        }

        public async Task<PagedTableReturnDto<Contacts>> GetPaged(int page)
        {
            var pageSize = 10;

            if (page < 1)
                page = 1;

            var totalRows = await Context.Contacts.AsNoTracking().CountAsync();

            var records = new PagedTableReturnDto<Contacts>()
            {
                Result = await Context.Contacts.OrderBy(a => a.Name).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(),
                CurrentPage = page,
                PageCount = (int)Math.Ceiling((double)totalRows / pageSize),
                TotalRecords = totalRows
            };

            return records;
        }


    }
}
