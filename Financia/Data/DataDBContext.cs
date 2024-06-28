using Financia.Models;
using Microsoft.EntityFrameworkCore;

namespace Financia.Data
{
    public class DataDBContext: DbContext
    {

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
