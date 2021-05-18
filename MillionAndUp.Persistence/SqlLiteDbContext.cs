using Microsoft.EntityFrameworkCore;
using MillionAndUp.Models.Models.Entity;

namespace MillionAndUp.Persistence
{
    public class SqlLiteDbContext : DbContext
    {
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
        {
        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyTrace> PropertyTrace { get; set; }
    }
}
