using Microsoft.EntityFrameworkCore;

namespace ProjectKlix.Models
{
    public class DbKlixContext : DbContext
    {
        public DbKlixContext()
        {
        }

        public DbKlixContext(DbContextOptions<DbKlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=DbKlix;Integrated Security=True;");
            }
        }
    }
}
