using Microsoft.EntityFrameworkCore;

namespace HomeWork2.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
    }
}
