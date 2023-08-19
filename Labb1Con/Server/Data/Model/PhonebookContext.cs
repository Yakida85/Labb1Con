using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Cryptography.X509Certificates;

namespace Labb1Con.Server.Data.Model
{
    public class PhonebookContext : DbContext

    {
        public PhonebookContext(DbContextOptions option) : base(option) 
        { 
         Database.EnsureCreated();
        }
        public DbSet<PhoneBook> PhonebooksTabel { get; set; }
    }
}
