using Microsoft.EntityFrameworkCore;
using TesteNdd.Entity;

namespace TesteNdd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
