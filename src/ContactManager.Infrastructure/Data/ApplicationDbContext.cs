using ContactManager.Domain.Contacts;
using ContactManager.Infrastructure.Data.ContactReads;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContactManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ContactRead> ContactReads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));
        }
    }
}
