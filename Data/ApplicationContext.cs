using Microsoft.EntityFrameworkCore;
using MiniApiThree.Models;

namespace MiniApiThree.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }

    }
}
