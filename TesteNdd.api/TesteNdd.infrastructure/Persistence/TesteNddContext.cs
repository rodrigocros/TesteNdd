using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Entities;

namespace TesteNdd.infrastructure.Persistence
{
    public class TesteNddContext : DbContext
    {
        public TesteNddContext(DbContextOptions<TesteNddContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> User { get; set; }
    }
}
