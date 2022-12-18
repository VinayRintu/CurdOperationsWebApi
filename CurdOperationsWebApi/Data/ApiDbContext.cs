using CurdOperationsWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace CurdOperationsWebApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
