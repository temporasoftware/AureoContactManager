using Microsoft.EntityFrameworkCore;
using WebApp.DbModels;

namespace WebApp.DbInfra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contacts> Contacts { get; set; }

    }
}
