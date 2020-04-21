using Microsoft.EntityFrameworkCore;

namespace ImageToSql.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserForm> UserForms { get; set; }
    }
}
