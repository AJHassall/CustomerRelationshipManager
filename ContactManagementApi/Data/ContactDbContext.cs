using Microsoft.EntityFrameworkCore;
using ContactManagementApi.Models;
namespace ContactManagementApi.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<ContactFundAssignment> ContactFundAssignments {get; set;}
    }
}