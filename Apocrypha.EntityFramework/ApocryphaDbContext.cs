using Apocrypha.CommonObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework
{
    public class ApocryphaDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }

        public ApocryphaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}