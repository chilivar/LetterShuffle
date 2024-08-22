using Microsoft.EntityFrameworkCore;

namespace ASPproject.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<Models.Words> words { get; set; }

        public DbSet<Models.User> users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
